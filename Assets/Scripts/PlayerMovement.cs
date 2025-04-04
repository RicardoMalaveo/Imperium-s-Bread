using JetBrains.Annotations;
using System.Collections;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //movemente variables
    public Rigidbody ricktusRB;
    public float movementSpeed;
    public float staminaLevel = 1;
    private Vector2 movementInput;
    public Transform playerBody;

    //Dash variables
    [SerializeField] public float dashSpeed = 5F;
    [SerializeField] public float dashTime = 0.5F;
    private Vector3 dashOrientation;
    private bool isDashing;
    private bool canDash;

    //Fall damage variables
    public CapsuleCollider capsuleCharacterCollider;
    public CameraBehavior cameraBehavior;
    private float groundedDistance;
    private float groundedDistanceBuffer = 0.1F;
    private float minimumFallDistance = 0.05F;
    private bool wasFalling;
    private float startOfFall;
    private bool isGrounded;
    private bool wasGrounded;

    //mouse variables to manage character direction
    public GameObject playerSprite;
    public Vector3 mouseLocation;

    void Update()
    {
        groundedDistance = (capsuleCharacterCollider.height / 2) + groundedDistanceBuffer;

        CheckGround();
    }

    private void FixedUpdate()
    {
        mouseLocation = Input.mousePosition;
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");
        var dashInput = Input.GetButtonDown("Jump");
        CharacterDirection();


        ricktusRB.linearVelocity = new Vector3(movementInput.x * movementSpeed, ricktusRB.linearVelocity.y, movementInput.y * movementSpeed);

        if (dashInput & canDash)
        {
            isDashing = true;
            canDash = false;

            dashOrientation = new Vector3(Input.GetAxisRaw("Horizontal"),0F, Input.GetAxisRaw("Vertical"));

            if (dashOrientation == Vector3.zero)
            {
                dashOrientation = new Vector3(transform.localScale.x, 0F);
            }

            StartCoroutine(StopDash());
        }

        if (isDashing)
        {
            ricktusRB.linearVelocity = dashOrientation * dashSpeed;
        }

        if(isGrounded)
        {
            canDash = true;
        }

        if (!wasFalling && isFalling)
        {
            startOfFall = transform.position.y;
        }

        if (!wasGrounded && isGrounded)
        {
            TakeDamage();
        }

        wasGrounded = isGrounded;
    }

    public void TakeDamage()
    {
        canDash = false;
        float fallDistance = startOfFall - transform.position.y;

        if(fallDistance > minimumFallDistance)
        {
            canDash = true;
            Coroutine coroutine = StartCoroutine(cameraBehavior.CameraShake(0.2F));
        }
    }

    public void CharacterDirection()
    {
        if(mouseLocation.x > Screen.currentResolution.width/2)
        {
            playerBody.transform.localRotation = Quaternion.Euler(playerBody.rotation.x, 180, playerBody.rotation.z);
        }
        else
        {
            playerBody.transform.localRotation = Quaternion.Euler(playerBody.rotation.x, 0, playerBody.rotation.z);
        }
    }

    private IEnumerator StopDash ()
    {
        yield return new WaitForSeconds (dashTime);
        isDashing = false;
    }

    void CheckGround()
    {
        RaycastHit hit;
        Color rayColor;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundedDistanceBuffer))
        {
            isGrounded = true;
            rayColor = Color.green;
        }
        else
        {
            isGrounded= false;
            rayColor = Color.red;
        }
        Debug.DrawRay(capsuleCharacterCollider.bounds.center, Vector3.down * (groundedDistance + groundedDistanceBuffer), rayColor);
    }

    bool isFalling 
    { 
        get 
        {
            return (!isGrounded && ricktusRB.linearVelocity.y < 0); 
        } 
    }
    }

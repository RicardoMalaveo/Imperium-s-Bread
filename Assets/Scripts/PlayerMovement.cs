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
    public float groundedDistanceBuffer = 0.1F;
    bool isGrounded;
    bool wasGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        groundedDistance = (capsuleCharacterCollider.height / 2) + groundedDistanceBuffer;

        CheckGround();
        if (!canDash)
        {
            Debug.Log("can't dash");
        }
    }

    private void FixedUpdate()
    {

        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");
        var dashInput = Input.GetButtonDown("Jump");


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

        if (!wasGrounded && isGrounded)
        {
            TakeDamage();
            Debug.Log("taking damage");
        }

        wasGrounded = isGrounded;
    }

    public void TakeDamage()
    {
        Coroutine coroutine = StartCoroutine(cameraBehavior.CameraShake(0.2F));

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
    }

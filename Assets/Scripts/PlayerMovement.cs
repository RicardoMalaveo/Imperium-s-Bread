using JetBrains.Annotations;
using System.Collections;
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

    [SerializeField]
    private RicktusAnimations ricktusAnimations;
    [SerializeField]
    private KnifeAttack knifeAttack;

    [SerializeField]
    private bool isMovingLeft;
    [SerializeField]
    private bool isLookingLeft;
    [SerializeField]
    private bool isMovingRight;
    [SerializeField]
    private bool isLookingRight;



    //Sound variables
    [SerializeField]
    private AudioManager audioManager;
    public AudioSource steps;
    void Update()
    {

        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            steps.enabled = true;
        }
        else
        {
            steps.enabled = false;
        }
            


        groundedDistance = (capsuleCharacterCollider.height / 2) + groundedDistanceBuffer;

        CheckGround();

        if (isMovingLeft && isLookingLeft && !knifeAttack.attacking || isMovingRight && isLookingRight && !knifeAttack.attacking)
        {
            ricktusAnimations.SetAnimations(ricktusAnimations.running, true, 1.2f);
        }
        else if (isMovingLeft && isLookingRight && !knifeAttack.attacking || isMovingRight && isLookingLeft && !knifeAttack.attacking)
        {
            ricktusAnimations.SetAnimations(ricktusAnimations.BackWalking, true, 1.2f);
        }
        else if(!knifeAttack.attacking)
        {
            ricktusAnimations.SetAnimations(ricktusAnimations.idle, true, 1f);
        }
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
            isLookingLeft = false;
            isLookingRight = true;
            playerBody.transform.localRotation = Quaternion.Euler(playerBody.rotation.x, 180, playerBody.rotation.z);
        }
        else
        {
            isLookingLeft = true;
            isLookingRight = false;
            playerBody.transform.localRotation = Quaternion.Euler(playerBody.rotation.x, 0, playerBody.rotation.z);
        }

        if(movementInput.x>0.1)
        { 
            isMovingLeft = false;
            isMovingRight = true;
        }
        else if (movementInput.x<-0.1)
        {
            isMovingLeft = true;
            isMovingRight = false;
        }
        else
        {
            isMovingLeft = false;
            isMovingRight = false;
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

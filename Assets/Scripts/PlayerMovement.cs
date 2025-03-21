using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



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

        if (IsGrounded())
        {
            canDash = true;
        }
    }

    private IEnumerator StopDash ()
    {
        yield return new WaitForSeconds (dashTime);
        isDashing = false;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
    }
}

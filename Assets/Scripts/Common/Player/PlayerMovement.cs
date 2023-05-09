using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float startMoveSpeed = 5f;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private bool isControlReversed;
    private float moveSpeed;
    
    //Jumping
    /*
    [SerializeField] private float jumpForce = 5f;
    private bool isJumping = false;
    private bool isGrounded = true;
    private float groundCheckDistance = 0.2f;
    private Transform groundCheckTransform;
    private LayerMask groundMask;
    */

    public float GetMovementSpeed()
    {
        return moveSpeed;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = startMoveSpeed;
        
        //Needs to be added to check if player is grounded for jumping
        /* 
        groundCheckTransform = transform.Find("GroundCheck");
        groundMask = LayerMask.GetMask("Ground");
        */
    }

    void FixedUpdate()
    {

        if (!isControlReversed)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            horizontalInput = -Input.GetAxis("Horizontal");
            verticalInput = -Input.GetAxis("Vertical");
        }
        rb.velocity = Vector3.zero;
        rb.MovePosition(rb.position + (new Vector3(horizontalInput, 0, verticalInput) * (moveSpeed * Time.deltaTime)));
        
        //Jumping, doesn't work due not moving using velocity I think
        /* 
        if (!Input.GetButtonDown("Jump")) return;
                
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundCheckDistance, groundMask);
        if (!isGrounded) return;
        
        Debug.Log("I should be jumping");
        // Allow jumping only if grounded
        isJumping = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        */
    }

    public void ToggleControl()
    {
        isControlReversed = !isControlReversed;
    }

    public void ToggleMovement()
    {
        if (Math.Abs(moveSpeed - startMoveSpeed) < 0.1f)
            moveSpeed = startMoveSpeed * 2;
        else
            moveSpeed = startMoveSpeed;
    }
}
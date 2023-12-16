using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //var of type rigidbody
    Rigidbody rb;
    //serializeField makes these values appear in unity editor
    //we can also use public
    //but then any other script would be able to access it
    //data encapsulation, lol
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    //transform var type to get the postition of the player
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {   //set the value once when the game starts
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //the same as using multiple if statements
        //to take into account the key pressed
        //but much more efficient
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);
        //get inputs and move the player
        //jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    bool IsGrounded()
    {
        //to check if the player has hit the ground
        //so he doesnt jump midair
        //unity has a readymade method for this
        //that creates a sphere and checks if the
        //sphere overlaps with the ground
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}

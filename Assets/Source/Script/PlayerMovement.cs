using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Get our Character Controller 
    public CharacterController controller;

    // Set our movement speed
    public float speed = 10f;
    // Set our gravity
    public float gravity = -19.62f;
    public float jumpHeight = 3f;

    // Set our CheckSpehere component
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Set our velocity component for jump
    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        // check are we at ground;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        // Get X & Z axis for movement if we prees key
        // Vertical axis : front = key W/ arrow up , and back = key S / arrow down
        float x = Input.GetAxis("Horizontal");

        // horizontal axis : right = key A/ arrow right, and left = key D / arrow left
        float z = Input.GetAxis("Vertical");

        // Define player local posistion
        Vector3 move = transform.right * x + transform.forward * z;

        // Moving player with local position
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}

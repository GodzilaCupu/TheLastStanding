using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Get our Character Controller 
    public CharacterController controller;

    // Set our movement speed
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Get X & Z axis for movement if we prees key

        // Vertical axis : front = key W/ arrow up , and back = key S / arrow down
        float x = Input.GetAxis("Horizontal");

        // horizontal axis : right = key A/ arrow right, and left = key D / arrow left
        float z = Input.GetAxis("Vertical");

        // Define player local posistion
        Vector3 move = transform.right * x + transform.forward * z;

        // Moving player with local position
        controller.Move(move * speed * Time.deltaTime);

    }
}

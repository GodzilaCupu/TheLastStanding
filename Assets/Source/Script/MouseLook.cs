using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this class is responsible to controll mouse movement for player looking 
// if you want, this class can join with player controller
public class MouseLook : MonoBehaviour
{
    // to controll mouse sensitivity
    public float mouseSensitifity = 100f;

    // reference to head of player;
    public Transform playerHead;

    //to control rotation (y axis) so player can't be flip
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // to lock cursor into middle of screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Define y and x axis for mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitifity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitifity * Time.deltaTime;

        // Control roatation ( Y axis ) so player view can't be fliped
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 85);

        // rotate up & down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // rotate left and right
        playerHead.Rotate(Vector3.up * mouseX);
    }
}

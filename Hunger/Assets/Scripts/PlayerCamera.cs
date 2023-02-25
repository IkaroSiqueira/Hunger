using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{ 
    public float sensX;
    public float sensY;
    public Transform orientation;
    float xRotation = 0;
    float yRotation = 0;

    private void Start()
    {
        //lock cursor in the middle of screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Invoke("ResetCamera", 0.4f);
    }

    private void ResetCamera()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        xRotation = 0;
        yRotation = 0;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}

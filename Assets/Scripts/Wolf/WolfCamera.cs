using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCamera : MonoBehaviour
{
    private float xRot;
    private float yRot;
    public float mouseSensetive = 8f;
    public GameObject Wolf;
    public Camera Camera;

    void MouseMove() 
    {
        xRot += Input.GetAxis("Mouse X");
        yRot -= Input.GetAxis("Mouse Y");

        
        Camera.transform.rotation = Quaternion.Euler(yRot, xRot, 0);
        Wolf.transform.rotation = Quaternion.Euler(0, xRot, 0);
    }

    private void Update()
    {
        MouseMove();
    }
}

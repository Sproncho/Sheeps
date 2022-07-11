using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{
    public int speed = 2;
    private CharacterController Wolf;
    float xMov;
    float zMov;
    Vector3 MoveDirection;
    void Start()
    {
        Wolf = GetComponent<CharacterController>();
    }

    void Movement() 
    {
        xMov = Input.GetAxis("Horizontal");
        zMov = Input.GetAxis("Vertical");
        MoveDirection = new Vector3(xMov, 0f, zMov);
        MoveDirection = transform.TransformDirection(MoveDirection);
        if (!Wolf.isGrounded)
        {
            MoveDirection.y -= 3f;
        }
        Wolf.Move(MoveDirection * Time.deltaTime);
    }
    void Update()
    {
        Movement();
    }
}

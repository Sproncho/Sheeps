using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{

   public int speed = 2;
    public GameObject Wolf;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Wolf.transform.position += Movement * speed * Time.deltaTime;
        Debug.Log("Movement");
    }
}

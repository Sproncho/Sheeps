using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCatching : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sheep") 
        {
            Destroy(collision.gameObject);
        }
    }
}

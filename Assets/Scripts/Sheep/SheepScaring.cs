using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScaring : MonoBehaviour
{
    SphereCollider Col;
    public GameObject Sheep;
    SheepAI ai;
    private void Start()
    {
        Col = GetComponent <SphereCollider>();
        ai = GetComponent<SheepAI>();
    }

    private void OnTriggerEnter(Collider Wolf)
    {
        Col.radius = 1;
        if (Wolf.gameObject.tag == "wolf")
        {
            Debug.Log("aggred");
            Sheep.GetComponent<Renderer>(). material.color = Color.red;
            Col.radius = 2;
            Debug.Log("aggred");
            ai.IsAggred = true;
            ai.Wolf = Wolf.gameObject;
        }
    }

    void OnTriggerStay(Collider Wolf)
    {
        if (Wolf.gameObject.tag == "wolf")
        {

            
        }
    }

    void OnTriggerExit(Collider Wolf)
    {
        if (Wolf.gameObject.tag == "wolf")
        {
            Sheep.GetComponent<Renderer>().material.color = Color.white;
          
            Col.radius = 1;
            ai.IsAggred = false;
            ai.Wolf = null;
        }
    }
}

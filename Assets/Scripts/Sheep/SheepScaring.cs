using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScaring : MonoBehaviour
{
    SphereCollider Col;
    public GameObject Sheep;
    private void Start()
    {
        Col = GetComponent <SphereCollider>();
        
    }

    private void OnTriggerEnter(Collider Wolf)
    {
        Col.radius = 1;
        if (Wolf.gameObject.tag == "wolf")
        {
            Sheep.GetComponent<Renderer>(). material.color = Color.red;
            Debug.Log("Расстояние " + Wolf.gameObject.tag + " до овцы <= 2 метра");
            Col.radius = 2;
            Debug.Log(Col.radius);
        }
    }

    void OnTriggerStay(Collider Wolf)
    {
        if (Wolf.gameObject.tag == "wolf")
        {

            //Пока волк в радиусе 4 от овцы она съебывает
            Debug.Log("Расстояние " + Wolf.gameObject.tag + " до овцы <= 4 метра");
            Debug.Log("Овца сваливает");
            //скрипт съебывания
        }
    }

    void OnTriggerExit(Collider Wolf)
    {
        if (Wolf.gameObject.tag == "wolf")
        {
            Sheep.GetComponent<Renderer>().material.color = Color.white;
            //как только волк покидает 4х метровый радиус
            Col.radius = 1;
            Debug.Log(Col.radius);
            Debug.Log("Овца гуляет");
        }
        
    }
}

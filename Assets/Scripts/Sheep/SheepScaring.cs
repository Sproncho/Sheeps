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
            Debug.Log("���������� " + Wolf.gameObject.tag + " �� ���� <= 2 �����");
            Col.radius = 2;
            Debug.Log(Col.radius);
        }
    }

    void OnTriggerStay(Collider Wolf)
    {
        if (Wolf.gameObject.tag == "wolf")
        {

            //���� ���� � ������� 4 �� ���� ��� ���������
            Debug.Log("���������� " + Wolf.gameObject.tag + " �� ���� <= 4 �����");
            Debug.Log("���� ���������");
            //������ ����������
        }
    }

    void OnTriggerExit(Collider Wolf)
    {
        if (Wolf.gameObject.tag == "wolf")
        {
            Sheep.GetComponent<Renderer>().material.color = Color.white;
            //��� ������ ���� �������� 4� �������� ������
            Col.radius = 1;
            Debug.Log(Col.radius);
            Debug.Log("���� ������");
        }
        
    }
}

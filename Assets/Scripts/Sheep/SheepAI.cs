

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepAI : MonoBehaviour
{
    private float speed = 2.0f;
    public float rotationSpeed = 100f;


    private bool isWandering = false;
    private bool isRotatingRight = false;
    private bool isRotatingLeft = false;
    private bool isWalking = false;
    private NavMeshAgent agent;
    Rigidbody rb;
    [HideInInspector]
    public bool IsAggred;
    [HideInInspector]
    public GameObject Wolf;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>  ();
    }


    private void Update()
    {
        if (!isWandering && !IsAggred)
        {
            //StartCoroutine(Wandering());
        }

        if (isRotatingRight)
        {
            transform.Rotate(transform.up * rotationSpeed * Time.deltaTime);
        }

        if (isRotatingLeft)
        {
            transform.Rotate(-transform.up * rotationSpeed * Time.deltaTime);
        }

        if (isWalking)
        {
            rb.velocity = (transform.forward * speed );
        }

        if (IsAggred)
        {
            Debug.Log("running");
            Vector3 dirToPlayer = transform.position - Wolf.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            agent.SetDestination(newPos);
        }
    }

    IEnumerator Wandering()
    {
        int rotationTime = Random.Range(1, 3);
        int rotationWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(5, 15);

        if (IsAggred)
        {
            yield break;
        }
        isWandering = true;

        yield return new WaitForSeconds(walkWait);

        isWalking = true;

        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        yield return new WaitForSeconds(rotationWait);

        if(rotateDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        if (rotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isWandering = false;

    }
}

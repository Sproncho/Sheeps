

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
    private bool isAggred;
    [HideInInspector]
    public GameObject Wolf;
    public IEnumerator coroutine;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (!isWandering && !isAggred)
        {
            coroutine = Wandering();
            StartCoroutine(coroutine);
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

        float dist = Vector3.Distance(Wolf.transform.position, transform.position);


        if (dist <= 2f)
        {
            StopCoroutine(coroutine);
            isWandering = false;
            isRotatingRight = false;
            isRotatingLeft = false;
            isWalking = false;
            GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("running");
            isAggred = true;
            agent.isStopped = false;
        }
        if (isAggred && !isWandering)
        {
            Vector3 dirToPlayer = transform.position - Wolf.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            agent.SetDestination(newPos);
        }
        if(dist > 4f)
        {
            GetComponent<Renderer>().material.color = Color.white;
            isAggred = false;
            agent.isStopped = true;
        }
    }

    IEnumerator Wandering()
    {
        int rotationTime = Random.Range(1, 3);
        int rotationWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(5, 15);

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

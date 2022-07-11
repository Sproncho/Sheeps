

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour
{
    private float speed = 1.0f;
    public float rotationSpeed = 100f;


    private bool isWandering = false;
    private bool isRotatingRight = false;
    private bool isRotatingLeft = false;
    private bool isWalking = false;

    Rigidbody rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (!isWandering)
        {
            StartCoroutine(Wandering());
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

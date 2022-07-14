using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepsController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] Sheeps = new GameObject[21];
    public GameObject SheepPrefab;
    public GameObject Wolf;
    void Start()
    {
        for (int i = 0; i < Sheeps.Length; i++)
        {
            Sheeps[i] = Instantiate(SheepPrefab, new Vector3(Random.Range(-24, 24), 1f, Random.Range(-24, 24)),Quaternion.identity);
            Sheeps[i].GetComponent<SheepAI>().Wolf = Wolf;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

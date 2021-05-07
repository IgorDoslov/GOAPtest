using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class Spawner : MonoBehaviour
{
    public GameObject patientPrefab;
    public int numPatients;
    public bool keepSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPatients; i++)
        {
            Instantiate(patientPrefab, transform.position, Quaternion.identity);
        }

        if (keepSpawning)
            Invoke("SpawnPatient", 4);

    }

    void SpawnPatient()
    {
        Instantiate(patientPrefab, transform.position, Quaternion.identity);
        Invoke("SpawnPatient", Random.Range(1, 10));
    }

    // Update is called once per frame
    void Update()
    {

    }
}

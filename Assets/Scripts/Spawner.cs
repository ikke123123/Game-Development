using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private float respawnTime;
    [SerializeField] private float modifier;

    [HideInInspector] public bool isRespawning = false;
    [HideInInspector] public int timeRemaining = 0;

    private GameObject spawnedObject;
    private float timer;

    private void Awake()
    {
        SpawnObject();
    }

    private void Update()
    {
        if (spawnedObject == null)
        {
            if (isRespawning == false)
            {
                isRespawning = true;
                timer = Time.time + respawnTime;
            }
            if (Time.time >= timer)
            {
                isRespawning = false;
                respawnTime *= modifier;
                SpawnObject();
            }
            timeRemaining = Mathf.FloorToInt(timer - Time.time);
            //Add UI timer for respawn
        }
    }

    private void SpawnObject()
    {
        spawnedObject = Instantiate(prefab, transform.position, transform.rotation);
        spawnedObject.GetComponent<Health>().healthUI = healthUI;
        spawnedObject.GetComponent<Health>().Initiate();
    }
}

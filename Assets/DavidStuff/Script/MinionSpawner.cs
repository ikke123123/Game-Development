using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public Transform minions;

    public float timeBetweenWaves = 25f;
    private float countdown = 2f;

    void Update()
    {
        if (countdown <= 0)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
     void SpawnWave()
    {
        Instantiate(minions);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public GameObject minions;
    public Transform goal;

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
        GameObject temptrans = Instantiate(minions);
        foreach (Transform transform in temptrans.GetComponentInChildren<Transform>())
        {
            transform.gameObject.GetComponent<moveScript>().goal = goal;
        }
    }
}

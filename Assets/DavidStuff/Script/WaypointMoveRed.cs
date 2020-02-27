using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMoveRed : MonoBehaviour
{

    public float speed = 5f;

    private Vector3 target;
    void Start ()
    {
        target = GameObject.Find("WaypointRed").transform.position;
    }

    void Update ()
    {
        Vector3 dir = target - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }
}

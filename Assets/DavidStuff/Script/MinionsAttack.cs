using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsAttack : MonoBehaviour
{
    private Transform target;

    //Color of Gizmos
    public Color Red = Color.red;
    /***********************************************************/
    public float range = 4f;
    public string enemyTag;

    public float speed = 3.5f;
    public GameObject effect;

    public float hitRate = 1f;
    private float hitCountdown = 0f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distancePerFrame, Space.World);

        if (dir.magnitude <= 1f)
        {
            if (hitCountdown <= 0)
            {
               HitTarget();
                hitCountdown = 1f / hitRate;
            }
            hitCountdown -= Time.deltaTime;
        }   
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Red;
        Gizmos.DrawSphere(transform.position, range);
    }

    void HitTarget()
    {
        //destroys all minions idk why, but it should work fine with health system I think
        Destroy(target.gameObject);
    }
}

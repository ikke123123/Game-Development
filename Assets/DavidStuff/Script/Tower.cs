using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform target;

    //Color of Gizmos
    public Color Red = Color.red;
    /************************************************************/


    [Header("TowerAttributes")]

    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 8f;

    public string enemyTag;

    public GameObject bulletPrefab;
    public Transform firePoint;

   
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
        }else
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
        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Red;
        Gizmos.DrawSphere(transform.position,range);
    }

    void Shoot()
    {
       GameObject bulletGO = (GameObject)Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
       Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Chase(target);
        }
    }
}

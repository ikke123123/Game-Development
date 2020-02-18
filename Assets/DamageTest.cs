using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour
{
    [SerializeField] private float damage = 0;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        health.TakeDamage(damage);
    }
}

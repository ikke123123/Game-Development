using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(100, 6000)] private int hp = 100;
    [SerializeField] private string healTag;
    [SerializeField] private HealthUI healthUI;

    [HideInInspector] public HealthData health = new HealthData();

    private readonly float healSpeed = 2; //Time in seconds to gain back a defined amount of health.

    private float timer;

    private void Awake()
    {
        health.Health = hp;
        healthUI.SetHealth(health);
        healthUI.UpdateHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //Take damage upon hit. And destroy arrow.
            //Add that stuff.
            //health.Damage(1);
            healthUI.UpdateHealth();
            return;
        }
        if (collision.gameObject.CompareTag(healTag))
        {
            timer = Time.time + healSpeed;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(healTag))
        {
            if (timer >= Time.time && health.Heal() == false)
            {
                healthUI.UpdateHealth();
                timer += healSpeed;
            }
        }
    }
}

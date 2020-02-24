using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(100, 6000)] private int hp = 100;
    [SerializeField] public HealthUI healthUI = null;

    [HideInInspector] public HealthData health = new HealthData();

    private readonly float healSpeed = 2; //Time in seconds to gain back a defined amount of health.

    private float timer;

    public void Initiate()
    {
        health.Health = hp;
        healthUI.SetHealth(health);
        healthUI.UpdateHealth();
    }

    public void TakeDamage(float amount)
    {
        //Add death script thing.
        health.Damage(amount);
        healthUI.UpdateHealth();
    }

    public void InitiateHeal()
    {
        timer = Time.time + healSpeed;
    }

    public void Heal()
    {
        if (timer <= Time.time && health.Heal() == false)
        {
            healthUI.UpdateHealth();
            timer += healSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class Health : MonoBehaviour
{
    [SerializeField, Range(100, 6000)] private int hp = 100;
    [SerializeField] public HealthUI healthUI = null;
    [SerializeField] private bool showHealthBarAbove = true;

    [HideInInspector] public HealthData health = new HealthData();

    private readonly float healSpeed = 2; //Time in seconds to gain back a defined amount of health.

    private float timer;

    private void Awake()
    {
        Initiate();
    }

    public void Initiate()
    {
        health.Health = hp;
        if (healthUI != null)
        {
            healthUI.SetHealth(health);
            healthUI.UpdateHealth();
        }
    }

    public void TakeDamage(float amount)
    {
        //Add death script thing.
        health.Damage(amount);
        if (healthUI != null) healthUI.UpdateHealth();
    }

    public void InitiateHeal()
    {
        timer = Time.time;
    }

    public void Heal()
    {
        if (timer <= Time.time && health.Heal() == false)
        {
            if (healthUI != null) healthUI.UpdateHealth();
            timer += healSpeed;
        }
    }
}

//[CustomEditor(typeof(Health))]
//[CanEditMultipleObjects]
//public class HealthEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        Health health = (Health)target;
//        health.hp = EditorGUILayout.IntField("HP", health.hp);
//    }

//}

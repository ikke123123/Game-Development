using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private List<Health> healthList = new List<Health>();

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Player") && other.gameObject.GetComponent<Health>())
        {
            Health tempHealth = other.gameObject.GetComponent<Health>();


        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private string objectTag = "";

    private List<Health> healthList = new List<Health>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(objectTag))
        {
            other.gameObject.GetComponent<Health>().InitiateHeal();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(objectTag))
        {
            other.gameObject.GetComponent<Health>().Heal();
        }
    }
}

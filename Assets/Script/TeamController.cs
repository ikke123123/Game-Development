using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    [Header("Team Selector")]
    [SerializeField] private Team team;

    [Header("Settings")]
    [SerializeField] private float bruh;

    [Header("Don't Touch")]
    [SerializeField] private GameObject assassin;
    [SerializeField] private GameObject archer;
    [SerializeField] private GameObject tank;


    /*Required options:
     *Public:
     * - Activate abilities
     * - Walk
     * - Activate normal attack
     * 
     *Private:
     * - Health:
     *      - Maintain current health
     *      - Healing when within certain region
     * - Receive damage:
     *      - Damage with damage number
     *      - 
     */
}

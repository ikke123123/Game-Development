using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] public GameObject assassin = null;
    [SerializeField] public GameObject archer = null;
    [SerializeField] public GameObject tank = null;
    [Header("Tower")]
    [SerializeField] public GameObject tower1 = null;
    [SerializeField] public GameObject tower2 = null;
    [SerializeField] public GameObject tower3 = null;
    [Header("Settings")]
    [SerializeField] public Team team;
    [SerializeField] public float speed = 10;

    [HideInInspector] public TeamMovement teamMovement;
    [HideInInspector] public TeamHealth teamHealth;

    private void Awake()
    {
        teamMovement = GetComponent<TeamMovement>();
        teamHealth = GetComponent<TeamHealth>();
    }

    //private GameObject GetHealthData(PlayerType playerType)
    //{
    //    switch (playerType)
    //    {
    //        case PlayerType.assassin:
    //            return assassin;
    //        case PlayerType.archer:
    //            return archer;
    //        case PlayerType.tank:
    //            return tank;
    //        case PlayerType.tower1:
    //            return tower1;
    //        case PlayerType.tower2:
    //            return tower2;
    //        case PlayerType.tower3:
    //            return tower3;
    //        default:
    //            return null;
    //    }
    //}
}

/*Required options:
 *Public:
 * - Activate abilities
 * - Activate normal attack
 * 
 *Private:
 * - Receive damage:
 *      - Damage with damage number
 */

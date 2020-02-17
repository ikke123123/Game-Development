using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamHealth : MonoBehaviour
{
    [HideInInspector] public HealthData assassin;
    [HideInInspector] public HealthData archer;
    [HideInInspector] public HealthData tank;
    [HideInInspector] public HealthData tower1;
    [HideInInspector] public HealthData tower2;
    [HideInInspector] public HealthData tower3;

    private TeamController teamController;

    private void Awake()
    {
        teamController = GetComponent<TeamController>();
        assassin = teamController.assassin.GetComponent<Health>().health;
        archer = teamController.archer.GetComponent<Health>().health;
        tank = teamController.tank.GetComponent<Health>().health;
        tower1 = teamController.tower1.GetComponent<Health>().health;
        tower2 = teamController.tower2.GetComponent<Health>().health;
        tower3 = teamController.tower3.GetComponent<Health>().health;
    }
}

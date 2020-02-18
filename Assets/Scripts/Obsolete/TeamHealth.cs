using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamHealth : MonoBehaviour
{
    [SerializeField] private float assassinHealth = 0;
    [SerializeField] private float archerHealth = 0;
    [SerializeField] private float tankHealth = 0;
    [SerializeField] private float tower1Health = 0;
    [SerializeField] private float tower2Health = 0;
    [SerializeField] private float tower3Health = 0;

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
        teamController.assassin.GetComponent<Health>().teamHealth = this;
        archer = teamController.archer.GetComponent<Health>().health;
        teamController.archer.GetComponent<Health>().teamHealth = this;
        tank = teamController.tank.GetComponent<Health>().health;
        teamController.tank.GetComponent<Health>().teamHealth = this;
        tower1 = teamController.tower1.GetComponent<Health>().health;
        teamController.tower1.GetComponent<Health>().teamHealth = this;
        tower2 = teamController.tower2.GetComponent<Health>().health;
        teamController.tower2.GetComponent<Health>().teamHealth = this;
        tower3 = teamController.tower3.GetComponent<Health>().health;
        teamController.tower3.GetComponent<Health>().teamHealth = this;
    }

    public void UpdateHealth()
    {
        assassinHealth = assassin.Health;
        archerHealth = archer.Health;
        tankHealth = tank.Health;
        tower1Health = tower1.Health;
        tower2Health = tower2.Health;
        tower3Health = tower3.Health; 
    }
}

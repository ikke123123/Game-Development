using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RedArcherAgent : Agent
{
    [SerializeField] private Transform target;

    private Vector3 startPos;
    private CharacterController characterController;
    private float speed = 10;
    private float timer = 25;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        startPos = transform.position;
    }

    public override void CollectObservations()
    {
        //Target and Agent Positions
        //AddVectorObs(target.position);
        //AddVectorObs(transform.position);

        //Agent Velocity
        AddVectorObs(characterController.velocity.x);
        AddVectorObs(characterController.velocity.x);
    }

    public override void AgentAction(float[] vectorAction)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.z = vectorAction[1];
        characterController.SimpleMove(controlSignal * speed);

        //float distanceToTarget = Vector3.Distance(transform.position, target.position);

        //if (distanceToTarget < 2)
        //{
        //    SetReward(100);
        //    Done();
        //}
        //if (distanceToTarget < 30)
        //{
        //    SetReward(5);
        //}

        //if (Time.time > timer)
        //{
        //    Done();
        //}

        if (transform.position.y < 0)
        {
            Done();
        }
    }

    public override float[] Heuristic()
    {
        float[] action = new float[2];
        action[0] = Input.GetAxis("Horizontal");
        action[1] = Input.GetAxis("Vertical");
        return action;
    }

    public override void AgentReset()
    {
        transform.position = startPos;
        timer = Time.time + 20;
    }
}

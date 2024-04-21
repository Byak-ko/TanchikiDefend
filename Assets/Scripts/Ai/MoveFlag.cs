using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Diagnostics;
using UnityEngine.Serialization;

public class MoveFlag : MonoBehaviour
{

    
    private NavMeshAgent agent;
    private GameObject flag;
    private Transform goal;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        flag = GameObject.Find("Base");
        goal = flag.transform;
        agent.destination = goal.position;
    }
}
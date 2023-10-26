using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patrol : MonoBehaviour
{
    //Declare the variables
    public Transform[] waypoints;
    public float stoppingDistance = 1f;
    public float idleTime = 2f;
    private NavMeshAgent agent;
    private int currentwaypointIndex = 0;
    private float idleTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextWaypoint();
    }
    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < stoppingDistance)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTime)
            {
                GoToNextWaypoint();
                idleTimer = 0f;
            }
        }
    }
    void GoToNextWaypoint()
    {
        currentwaypointIndex = (currentwaypointIndex + 1) % waypoints.Length;
        agent.destination = waypoints[currentwaypointIndex].position;
    }
}

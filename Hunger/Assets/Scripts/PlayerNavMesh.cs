using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    bool arrived;
    bool patrolling;
    int destination;
    //Needs Animator
    public Transform eye;
    public Transform target;
    Vector3 lastPosition;
    private float _detectionRange = 6f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolling = true;
        lastPosition = transform.position;
        StartCoroutine("GoToNextPatrolPoint");
    }
    bool CanSeePlayer()
    {
        bool canSee = false;
        Ray ray = new Ray(eye.position, target.transform.position - eye.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _detectionRange))
        {
            if(hit.transform != target)
            {
                canSee = false;
            }
            //will return the enemy back to where it was before it saw you
            else
            {
                lastPosition = target.transform.position;
                canSee = true;
            }
        }
        return canSee;
    }
    private void Update()
    {
        if (agent.pathPending)
        {
            return;
        }

        if (patrolling)
        {
            //arrived at waypoint
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                if (!arrived)
                {
                    arrived = true;
                    StartCoroutine("GoToNextPatrolPoint");
                }
            }
            else
            {
                arrived = false;
            }
        }
        if (CanSeePlayer())
        {
            agent.SetDestination(target.transform.position);
            patrolling = false;
        }
        else
        {
            if (!patrolling)
            {
                agent.SetDestination(lastPosition);
                if(agent.remainingDistance < agent.stoppingDistance)
                {
                    patrolling = true;
                    StartCoroutine("GoToNextPatrolPoint");
                }
            }
        }
    }
    IEnumerator GoToNextPatrolPoint()
    {
        // check length of waypoints
        if (waypoints.Length == 0)
        {
            yield break;
        }

        patrolling = true;
        yield return new WaitForSeconds(1.0f);
        arrived = false;
        agent.destination = waypoints[destination].position;
        destination = (destination + 1) % waypoints.Length;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform player;
    public int followDistance;
    public GameObject warningImg;

    int m_CurrentWaypointIndex;
    bool m_Follow = false;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        m_Follow = false;
        var heading = player.position - transform.position;
        var distance = heading.magnitude;

        if(distance < followDistance && !m_Follow) 
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    m_Follow = true;
                    warningImg.SetActive(true);
                    navMeshAgent.SetDestination(player.position);
                }
            }
        }

        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            warningImg.SetActive(false);
        }
    }
}

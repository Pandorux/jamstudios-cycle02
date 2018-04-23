using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Wander : MonoBehaviour {

    [HideInInspector]
    public NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(GetNewTargetLoc(10));
    }

    void Update()
    {
        if(1 <= Vector3.Distance(agent.destination, transform.position)) {
            agent.SetDestination(GetNewTargetLoc(10));
        }
        
    }

    Vector3 GetNewTargetLoc(float moveRadius) {
        Vector3 ranDir = Random.insideUnitSphere * moveRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(ranDir, out hit, moveRadius, NavMesh.AllAreas);
        Debug.Log(hit.position);
        return hit.position;
    }

}

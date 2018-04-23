using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class Wander : MonoBehaviour {

    [HideInInspector]
    public NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(GetNewTargetLoc(100));
    }

    void Update()
    {
        if(1 <= Vector3.Distance(agent.destination, transform.position)) {
            agent.SetDestination(GetNewTargetLoc(10));
            //Debug.Log(agent.destination);
        }
        
    }

    Vector3 GetNewTargetLoc(float moveRadius) {
        Vector3 ranDir = Random.insideUnitSphere * moveRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(ranDir, out hit, moveRadius, NavMesh.AllAreas);
        return hit.position;
    }

}

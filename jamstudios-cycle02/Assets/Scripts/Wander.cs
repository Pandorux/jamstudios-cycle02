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

        Debug.Log("Dist: " + Vector3.Distance(agent.destination, transform.position) +
            "\nDest: " + agent.destination + "\t, Cur: " + transform.position);

        if(1 >= Vector3.Distance(agent.destination, transform.position)) {
            agent.SetDestination(GetNewTargetLoc(100));
            Debug.DrawRay(agent.destination, Vector3.up);
            //Debug.Log(agent.destination);
        }
        
    }

    Vector3 GetNewTargetLoc(float moveRadius) {
        Vector3 ranPoint = transform.position + Random.insideUnitSphere * moveRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(ranPoint, out hit, moveRadius, NavMesh.AllAreas);
        return hit.position;
    }

    Vector3 GetNewTargetLoc()
    {
        NavMeshTriangulation tri = NavMesh.CalculateTriangulation();
        int t = Random.Range(0, tri.vertices.Length - 3);
        return tri.vertices[t];
    }
}

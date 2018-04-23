using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Wander))]
public class ChickenControoller : MonoBehaviour {

    public float health;
    public float moveSpeed;
    public Animator animator;
    public bool isAlive;

	// Use this for initialization
	void Start () {
        GetComponent<NavMeshAgent>().speed = moveSpeed;
        isAlive = true;
	}

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    public void Death()
    {
        animator.Play("death");
    }
}

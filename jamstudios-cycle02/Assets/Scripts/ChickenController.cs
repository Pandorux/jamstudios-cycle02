using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Wander))]
public class ChickenController : MonoBehaviour {

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
        Debug.Log("Chicken be hurt");
        health -= dmg;

        if (health <= 0)
            isAlive = false;

        if (!isAlive)
            Death();
    }

    public void Death()
    {
        Debug.Log("Chicken be dead");
        animator.Play("Armature|Death");
        GameController.chickensKilled++;
        GameController.chickensAlive--;
        GetComponent<NavMeshAgent>().speed = 0;
    }
}

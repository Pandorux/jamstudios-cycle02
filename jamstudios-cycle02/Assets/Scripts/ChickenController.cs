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
    public AudioSource deathSound;

	// Use this for initialization
	void Start () {
        GetComponent<NavMeshAgent>().speed = moveSpeed;
        isAlive = true;
	}

    public void TakeDamage(float dmg)
    {

        health -= dmg;

        if (health <= 0)
            isAlive = false;

        if (!isAlive)
            Death();
    }

    public void Death()
    {
        animator.Play("Armature|Death");
        deathSound.Play();
        GameController.instance.chickensKilled++;
        GameController.instance.chickensAlive--;
        GetComponent<NavMeshAgent>().speed = 0;
    }
}

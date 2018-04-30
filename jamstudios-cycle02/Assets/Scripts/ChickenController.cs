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
    public AudioSource deathSource;
    public AudioClip[] deathSounds;
    [Range(0, 5)]
    public float deathDelay = 2.0f;

    // Use this for initialization
    void Start () {
        GetComponent<NavMeshAgent>().speed = moveSpeed;
        isAlive = true;

        deathSource.clip = deathSounds[Random.Range(0, deathSounds.Length)];
        GetComponent<AudioSource>().volume *= SoundController.instance.ReturnSoundVolume();
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
        deathSource.Play();
        GameController.instance.chickensKilled++;
        GameController.instance.chickensAlive--;
        GetComponent<NavMeshAgent>().speed = 0;
        StartCoroutine(DestroyChicken(deathDelay));
    }

    private IEnumerator DestroyChicken(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

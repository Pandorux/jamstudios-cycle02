using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Wander))]
public class ChickenController : MonoBehaviour {



    public float health;
    public float moveSpeed;
    public Animator animator;
    public bool hasDied;
    public AudioSource deathSource;
    public AudioClip[] deathSounds;
    [Range(0, 5)]
    public float deathDelay = 2.0f;

    // Use this for initialization
    void Start () {
        GetComponent<NavMeshAgent>().speed = moveSpeed;
        hasDied = false;

        deathSource.clip = deathSounds[Random.Range(0, deathSounds.Length)];
        GetComponent<AudioSource>().volume *= SoundController.instance.ReturnSoundVolume();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (hasDied == false && health <= 0)
            Death();
    }

    public void Death()
    {
        hasDied = true;
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

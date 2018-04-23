using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoSpawner : MonoBehaviour {

    public float spawnRate;
    public GameObject chicken;

    private float spawnTime;

    void Start()
    {
        spawnTime += spawnRate;
    }

	// Update is called once per frame
	void Update () {

        if (spawnTime <= Time.time)
        {
            Vector3 spawnLoc = new Vector3(PlayerController.player.transform.position.x, 1, PlayerController.player.transform.position.z);
            Instantiate(chicken, spawnLoc, Quaternion.identity);
            spawnTime = Time.time + spawnRate;
        }
       
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoSpawner : MonoBehaviour {

    public float spawnRate;
    public GameObject chicken;
    public float spawnRateDecrease = 0.15f;

    private float spawnTime;
    private int chickensSpawned;

    void Start()
    {
        spawnTime = spawnRate;
        chickensSpawned = 0;
    }

	// Update is called once per frame
	void Update () {

        if (GameController.instance.isGameRunning)
        {
            if (spawnTime <= Time.time)
            {
                Vector3 spawnLoc = new Vector3(PlayerController.instance.transform.position.x, 1, PlayerController.instance.transform.position.z);
                Instantiate(chicken, spawnLoc, Quaternion.identity);
                GameController.chickensAlive++;
                chickensSpawned++;
                spawnTime = Time.time + spawnRate;

                if ((chickensSpawned % 5) == 0 && spawnTime > spawnRateDecrease)
                {
                    //Debug.Log("Chickens: " + chickensSpawned + "\n Time: " + Time.time);
                    spawnRate -= spawnRateDecrease;
                }
            }
        }
	}
}

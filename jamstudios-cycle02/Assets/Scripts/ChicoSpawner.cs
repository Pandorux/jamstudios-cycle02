using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoSpawner : MonoBehaviour {

    public float spawnRate;
    public GameObject chicken;

    private bool spawnChicken;
	
	// Update is called once per frame
	void Update () {
        if (((int)Time.time % spawnRate) == 0 && spawnChicken)
        {
            Vector3 spawnLoc = new Vector3(PlayerController.player.transform.position.x, 1, PlayerController.player.transform.position.z);
            Instantiate(chicken, spawnLoc, Quaternion.identity);
            spawnChicken = false;
        }
        
        if (((int)Time.time % spawnRate) != 0)
        {
            spawnChicken = true;
        }
	}
}

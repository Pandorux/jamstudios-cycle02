using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoSpawner : MonoBehaviour {

    public float spawnRate;
    public GameObject chicken;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Time.fi % spawnRate) == 0)
        {
            Instantiate(chicken);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public static GameController instance = null;

    public AudioClip testSound;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
        PlayerInput();
	}

    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SoundController.instance.CreateNewSound(testSound);
        }
    }
}

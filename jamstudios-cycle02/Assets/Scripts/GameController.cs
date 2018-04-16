using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public static GameController instance = null;

    public AudioClip testSound;

    private bool isGamePaused;

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
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                ChangeTimeState(0.0f);
                isGamePaused = true;
            }
            else
            {
                ChangeTimeState(1.0f);
                isGamePaused = false;
            }
        }
    }

    void ChangeTimeState(float newGameSpeed)
    {
        Time.timeScale = newGameSpeed;
    }
}

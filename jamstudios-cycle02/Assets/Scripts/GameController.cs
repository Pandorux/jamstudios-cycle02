using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public static GameController instance = null;

    public GameObject menu;
    public AudioClip testSound;

    private bool isGamePaused;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
	}

    void Start ()
    {
        menu.SetActive(false);
        isGamePaused = false;
    }

	// Update is called once per frame
	void Update () {
        PlayerInput();
	}

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SoundController.instance.CreateNewSound(testSound);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseState();
            menu.SetActive(isGamePaused);
        }
    }

    public void ChangeTimeState(float newGameSpeed)
    {
        Time.timeScale = newGameSpeed;
    }

    public void ChangePauseState()
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

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadSceneAsync(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    public void LoadSceneAsync(int buildIndex)
    {
        SceneManager.LoadSceneAsync(buildIndex);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

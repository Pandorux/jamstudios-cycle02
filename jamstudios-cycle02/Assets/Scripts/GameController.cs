using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [HideInInspector]
    public static GameController instance = null;
    [HideInInspector]
    public static int chickensAlive = 0;
    [HideInInspector]
    public static int chickensKilled = 0;

    [Range(0, 100)]
    public int loseThreshold = 25;
    public GameObject menu;
    public AudioClip testSound;

    private bool isGamePaused;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        menu.SetActive(false);
        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        GameConditions();
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

    public void GameConditions()
    {
        if (chickensAlive >= loseThreshold)
        {
            Time.timeScale = 0;
            PlayerController.player.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().cameraActive = false;
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
        PlayerController.player.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().cameraActive = false;
    }
    else
    {
        ChangeTimeState(1.0f);
        isGamePaused = false;
        PlayerController.player.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().cameraActive = true;
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

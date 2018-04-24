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
    [HideInInspector]
    public bool isGameRunning;

    [Range(0, 1000)]
    public int loseThreshold = 25;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

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
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        isGamePaused = false;
        isGameRunning = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        GameConditions();
    }

    private void PlayerInput()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    SoundController.instance.CreateNewSound(testSound);
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseState();
            pauseMenu.SetActive(isGamePaused);
        }
    }

    public void GameConditions()
    {
        if (chickensAlive >= loseThreshold)
        {
            Time.timeScale = 0;
            isGameRunning = false;
            PlayerController.instance.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().cameraActive = false;
            gameOverMenu.SetActive(true);        
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
            pauseMenu.SetActive(true);
            ChangeTimeState(0.0f);
            isGamePaused = true;
            Cursor.visible = true;
            PlayerController.instance.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().cameraActive = false;
        }
        else
        {
            pauseMenu.SetActive(false);
            ChangeTimeState(1.0f);
            isGamePaused = false;
            Cursor.visible = false;
            PlayerController.instance.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().cameraActive = true;
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

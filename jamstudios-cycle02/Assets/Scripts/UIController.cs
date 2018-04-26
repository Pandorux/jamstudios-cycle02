using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour {

    public static UIController instance;

    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public TextMeshProUGUI timeSurvivedText;
    public TextMeshProUGUI chickensKilledText;
    public TextMeshProUGUI goTimeSurvivedText;
    public TextMeshProUGUI goChickensKilledText;
    public TextMeshProUGUI finalScoreText;

    void Awake ()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

	// Use this for initialization
	void Start () {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
	}

    // TODO: Update the Time Survived UI
    void UpdateTimer()
    {
        
    }

    // TODO: Update the Chickens Killed UI
    void UpdateChickensKilled()
    {

    }

    public void GameOverScreen() 
    {
        gameOverMenu.SetActive(true);
        goTimeSurvivedText.text = ((int)GameController.instance.timeSurvived).ToString();
        goChickensKilledText.text = GameController.instance.chickensKilled.ToString();
        finalScoreText.text = GameController.instance.PlayerScore().ToString();
    }

}

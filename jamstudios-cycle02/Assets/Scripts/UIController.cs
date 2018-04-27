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
    public GameObject hud;
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
    public void UpdateTimer()
    {

        timeSurvivedText.text = ((int)GameController.instance.timeSurvived).ToString();

    }

    // TODO: Update the Chickens Killed UI
    public void UpdateChickensKilled()
    {

        chickensKilledText.text = GameController.instance.chickensKilled.ToString();
    }

    public void GameOverScreen() 
    {
        gameOverMenu.SetActive(true);
        goTimeSurvivedText.text = ((int)GameController.instance.timeSurvived).ToString();
        goChickensKilledText.text = GameController.instance.chickensKilled.ToString();
        finalScoreText.text = GameController.instance.PlayerScore().ToString();
    }

}

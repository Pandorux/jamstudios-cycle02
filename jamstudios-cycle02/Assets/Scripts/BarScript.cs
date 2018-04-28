using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    private void HandleBar()
    {
        content.fillAmount = Map(GameController.instance.chickensAlive,0,GameController.instance.loseThreshold,0,1);
    }

    private float Map(float chickensAlive, float chickenMin, float chickenMax, float editorMin ,float editorMax)
    {
        return (chickensAlive - chickenMin) * (editorMax - editorMin) / (chickenMax - chickenMin) + editorMin;
    }
}

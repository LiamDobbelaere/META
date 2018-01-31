using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScoreText : MonoBehaviour {
    private GlobalState globalState;
    private Text text;
    private GameObject restartButton;

    private string[] multiplierColors = { "white", "yellow", "orange", "red", "green", "aqua" };

	// Use this for initialization
	void Start () {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
        restartButton = GameObject.Find("Restart");
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        restartButton.SetActive(globalState.ship.isDead);

        string multiplierColor = "aqua";

        if (globalState.scoreMultiplier <= multiplierColors.Length)
        {
            multiplierColor = multiplierColors[globalState.scoreMultiplier - 1];
        }

        text.text = string.Format(" Score: {0}\n Multiplier: <color={1}>x{2}</color>", 
            (int) globalState.score, 
            multiplierColor,
            globalState.scoreMultiplier.ToString());
	}
}

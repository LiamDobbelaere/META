using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScoreText : MonoBehaviour {
    private GlobalState globalState;
    private Text text;
    private GameObject restartButton;

    private int lastMultiplier;
    private string multiplierColor;

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

        if (lastMultiplier != globalState.scoreMultiplier)
        {
            multiplierColor = ColorUtility.ToHtmlStringRGB(globalState.getMainColor());
            lastMultiplier = globalState.scoreMultiplier;
        }
        
        text.text = string.Format(" Score: {0}\n Section: <color=#{1}>{2}</color>", 
            (int) globalState.score, 
            multiplierColor,
            globalState.scoreMultiplier.ToString());
	}
}

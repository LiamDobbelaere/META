using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowmotionUI : MonoBehaviour {
    private GlobalState globalState;
    private Image slomoImage;
    private Sprite slomoSprite;

	// Use this for initialization
	void Start () {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
        slomoImage = GetComponent<Image>();
        slomoSprite = slomoImage.sprite;
	}
	
	// Update is called once per frame
	void Update () {
        slomoImage.enabled = globalState.ship.hasSlowmotion;
	}
}

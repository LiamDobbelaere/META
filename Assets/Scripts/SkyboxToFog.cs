using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SkyboxToFog : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        RenderSettings.skybox.SetColor("_Tint", RenderSettings.fogColor);
        RenderSettings.skybox.SetColor("_GroundColor", RenderSettings.fogColor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

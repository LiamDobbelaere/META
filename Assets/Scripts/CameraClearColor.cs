using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraClearColor : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GetComponent<Camera>().backgroundColor = RenderSettings.fogColor;
	}
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Camera>().backgroundColor = RenderSettings.fogColor;
	}
}

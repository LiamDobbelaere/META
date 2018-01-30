using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkObstacle : MonoBehaviour {
    private Material myMaterial;
    private float timePassed;

	// Use this for initialization
	void Start () {
        myMaterial = GetComponent<Renderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        myMaterial.SetColor("_Color", Color.Lerp(myMaterial.GetColor("_Color"), new Color(255f / 255f, 75f / 255.0f, 0), 0.01f));

        /*timePassed += Time.deltaTime;

        if (timePassed > 1f)
        {
            timePassed = 0f;
            myMaterial.SetColor("_Color", Color.black);
        }
        */
	}
}

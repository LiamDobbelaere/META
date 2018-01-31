using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkObstacle : MonoBehaviour {
   private Material myMaterial;
   private float time;

   /*private float timePassed;

    public Color targetColor = new Color(255f / 255f, 75f / 255.0f, 0);
    */
	// Use this for initialization
	void Start () {
        myMaterial = GetComponent<Renderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > 0.05f)
        {
            Color myColor = myMaterial.GetColor("_Color");

            myColor.a = Random.Range(0.2f, 0.7f);

            myMaterial.SetColor("_Color", myColor);

            time = 0f;
        }

        //myMaterial.SetColor("_Color", //Color.Lerp(myMaterial.GetColor("_Color"), targetColor, 0.01f));

        /*timePassed += Time.deltaTime;

        if (timePassed > 1f)
        {
            timePassed = 0f;
            myMaterial.SetColor("_Color", Color.black);
        }
        */
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArrowsToColor : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Color myColor = transform.GetComponent<Renderer>().materials[0].GetColor("_Color");
        myColor.a = 1f;

        foreach (Transform t in transform)
        {
            if (t.gameObject.name.Equals("arrow"))
            {
                t.GetComponent<Renderer>().materials[0].SetColor("_Color", myColor);
            }
        }
	}
}

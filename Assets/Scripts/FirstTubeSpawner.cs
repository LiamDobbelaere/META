using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTubeSpawner : MonoBehaviour {
    public Transform spawnMe;
    public GlobalState globalState;

	// Use this for initialization
	void Start () {
        var inst = Instantiate(spawnMe, transform.position, transform.rotation);
        var atb = inst.gameObject.AddComponent<AutoTubeBuilder>();
        //atb.globalState = globalState;

        var instRenderer = inst.GetComponent<Renderer>();
        var doc = inst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = this.gameObject;

        instRenderer.materials[0].SetColor("_Color", globalState.getMainColor());
        instRenderer.materials[1].SetColor("_EmissionColor", globalState.getTubeColor());
        instRenderer.materials[2].SetColor("_Color", globalState.getAccentColor());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

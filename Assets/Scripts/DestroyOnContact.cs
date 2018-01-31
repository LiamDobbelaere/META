using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
    public GameObject target;

    private GlobalState globalState;

    private bool triggered;
    private float destroyTime = 3f;

	// Use this for initialization
	void Start () {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
    }

	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            destroyTime -= Time.deltaTime;
        }

        if (destroyTime <= 0)
        {
            if (globalState.activeTubes > 0) globalState.activeTubes--;

            Destroy(target);
            Destroy(this);
        }
	}
}

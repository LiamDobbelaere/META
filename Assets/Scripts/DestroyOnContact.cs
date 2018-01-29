using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
    public GameObject target;

    private bool triggered;
    private float destroyTime = 3f;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            triggered = true;
    }

	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            destroyTime -= Time.deltaTime;
        }

        if (destroyTime <= 0)
        {
            Destroy(target);
            Destroy(this);
        }
	}
}

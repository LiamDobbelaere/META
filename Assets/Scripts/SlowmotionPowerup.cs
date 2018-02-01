using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmotionPowerup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ShipController>().hasSlowmotion = true;
            other.gameObject.GetComponent<ShipController>().PlayPowerupPickup();
        }

        Destroy(gameObject);
    }
}

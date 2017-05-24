using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaknessBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D()
    {
        GameObject.Find("GameMaster").GetComponent<HealthBarScript>().health -= 5f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaknessBehaviour : MonoBehaviour {
    public float timer = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Die();
        }
	}
    private void OnTriggerEnter2D()
    {
        GameObject.Find("GameMaster").GetComponent<HealthBarScript>().health -= 5f;
        Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

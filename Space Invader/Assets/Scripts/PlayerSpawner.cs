using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {
    public Text textLives;
    public GameObject playerPrefab;
    GameObject playerInstance;
    int numLives = 4;
    float respawnTimer;
	void Start () {
        SpawnPlayer();
	}
	void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject) Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerInstance.name = "Player";
    }
	// Update is called once per frame
	void Update ()
    {
        textLives.text = "x" + numLives.ToString();
        if (playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
	}
    public void finished()
    {

    }
}

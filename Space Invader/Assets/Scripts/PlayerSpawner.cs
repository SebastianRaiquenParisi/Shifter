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
    public GameObject GameOverUI;
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
	void Update ()
    {
        if (numLives == 0 && playerInstance==null)
        {
            GameOver();
        }
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
    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    GameObject[] arrayHearts = new GameObject[3];
    public int health = 3;
    public float invulnPeriod = 1.5f;
    float invulnTimer = 0;
    int correctLayer;
    void Start()
    {
        arrayHearts[0] = GameObject.Find("Heart1");
        arrayHearts[1] = GameObject.Find("Heart2");
        arrayHearts[2] = GameObject.Find("Heart3");
        HeartsSetActive();
        correctLayer = gameObject.layer;
    }
    void OnTriggerEnter2D()
    {
        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
        arrayHearts[health].SetActive(false);

    }
    void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;

            }
        }

        if (health <= 0)
        {
            HeartsSetActive();
            Die();
        }
    }
    void HeartsSetActive()
    {
        arrayHearts[0].SetActive(true);
        arrayHearts[1].SetActive(true);
        arrayHearts[2].SetActive(true);
    }
    void Die()
    {
        Destroy(gameObject);
    }

}

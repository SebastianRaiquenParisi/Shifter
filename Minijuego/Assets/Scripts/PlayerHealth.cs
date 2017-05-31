using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {

    GameObject[] arrayHearts = new GameObject[3];
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int health = 3;
    public float invulnPeriod = 1.5f;
    float invulnTimer = 0;
    int correctLayer;

    void Start()
    {
        
        for (int i = 0; i < 3; i++)
        {
            arrayHearts[i] = GameObject.Find("Heart" + (i+1).ToString());
        }
        FullHearts();
        correctLayer = gameObject.layer;
    }
    void OnTriggerEnter2D()
    {
        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
        if (health >= 0)
        {
            arrayHearts[health].GetComponent<Image>().sprite = emptyHeart;
        }

    }
    void OnCollisionEnter2D()
    {
        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
        if (health >= 0)
        {
            arrayHearts[health].GetComponent<Image>().sprite = emptyHeart;
        }

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
            FullHearts();
            Die();
        }
    }
    void FullHearts()
    {
        for (int i = 0; i < 3; i++)
        {
            arrayHearts[i].GetComponent<Image>().sprite = fullHeart;
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

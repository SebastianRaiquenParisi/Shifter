using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthMovement : MonoBehaviour {

    public GameObject SuperAttack;
    public Image healthBar;
    public float startHealth = 30;
    public float health;

    // Use this for initialization
    void Start()
    {
        health = startHealth;
    }
    void OnTriggerEnter2D()
    {
        health--;
    }
    // Update is called once per frame
    void Update()
    {
        TakeDamage();
    }
    public void TakeDamage()
    {
        healthBar.fillAmount = health / startHealth;
    }
}

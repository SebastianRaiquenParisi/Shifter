﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image healthBar;
    public float startHealth = 50f;
    public float health;
    // Use this for initialization
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / startHealth;
    }
}
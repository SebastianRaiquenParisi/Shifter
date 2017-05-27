using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStrayForward : MonoBehaviour {
    public int health = 1;
    public int maxSpeed = 5;
    public float tiempoAntesDeDispararse = 3f;

    void Start()
    {

    }
    void OnTriggerEnter2D()
    {
        health--;

    }
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        if (tiempoAntesDeDispararse <= 0)
        {
            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
            pos += transform.rotation * velocity;
            transform.position = pos;
            return;
        }
        tiempoAntesDeDispararse -= Time.deltaTime;
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

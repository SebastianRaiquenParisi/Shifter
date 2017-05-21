using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletDoesntFollow : MonoBehaviour {
    public int health = 1;
    public int maxSpeed = 5;
    public float tiempoParaBuscarAlPersonaje = 3f;
    public float rotSpeed = 90f;
    Transform player;

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
        if(tiempoParaBuscarAlPersonaje <= 0)
        {
            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
            pos += transform.rotation * velocity;
            transform.position = pos;
            return;
        }
        if (player == null)
        {
            GameObject gObj = GameObject.Find("Player");
            if (gObj != null)
            {
                player = gObj.transform;
            }
        }
        if (player == null)
        {
            return;
        }

        tiempoParaBuscarAlPersonaje -= Time.deltaTime;
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        



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

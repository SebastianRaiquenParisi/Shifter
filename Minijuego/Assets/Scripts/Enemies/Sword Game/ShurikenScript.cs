using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour {
    public int health = 1;
    public float tiempoDePerseguir = 9f;
    public int maxSpeed = 20;
    public float rotSpeed = 90f;
    public int maxSpeedNotFollow = 30;
    public float rotSpeedNotFollow = 900f;
    public float tiempoParaBuscarAlPersonaje = 3f;
    Transform player;

    void OnTriggerEnter2D()
    {
        health--;

    }
    // Update is called once per frame
    void Update() {
        if (health <= 0)
        {
            Die();
        }
        if (tiempoDePerseguir > 0)
        {
            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
            pos += transform.rotation * velocity;
            transform.position = pos;

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
            Vector3 dir = player.position - transform.position;
            dir.Normalize();
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
            tiempoDePerseguir -= Time.deltaTime;
        }
        else
        {
            if (tiempoParaBuscarAlPersonaje <= 0)
            {
                Vector3 pos = transform.position;
                Vector3 velocity = new Vector3(0, maxSpeedNotFollow * Time.deltaTime, 0);
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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeedNotFollow * Time.deltaTime);
        }
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

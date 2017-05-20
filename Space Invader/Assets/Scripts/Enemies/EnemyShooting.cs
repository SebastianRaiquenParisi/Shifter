using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public float fireDelay = 0.5f;
    float cooldownTimer = 0;
    public float distanciaDeDisparo = 20;

    Transform player;

    int bulletLayer;
    private void Start()
    {
        bulletLayer = gameObject.layer;
    }
    void Update()
    {
        if (player == null)
        {
            GameObject gObj = GameObject.Find("Player");
            if (gObj != null)
            {
                player = gObj.transform;
            }
        }
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < distanciaDeDisparo)
        {
            //Fire
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * new Vector3(0, 1.3f, 0);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}

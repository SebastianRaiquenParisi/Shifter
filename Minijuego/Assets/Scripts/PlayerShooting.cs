using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public GameObject bulletPrefab;
    public float fireDelay = 1.1f;
    float cooldownTimer = 0;
    int bulletLayer;
    private void Start()
    {
        bulletLayer = gameObject.layer;
    }
    void Update () {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            //Fire
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * new Vector3(0,1.3f,0);
            GameObject bulletGO = Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerLaser : MonoBehaviour {

    float enemyRate = 4;
    float nextEnemy = 1;
    float spawnDistance = 20;
    public GameObject[] enemyPrefab;
    public GameObject SuperAttack;
    public float countdown4SuperAttack = 3;
    float startingCountdown;

    private void Start()
    {
        startingCountdown = countdown4SuperAttack;
    }

    void Update()
    {
        nextEnemy -= Time.deltaTime;
        if (nextEnemy <= 0)
        {
            countdown4SuperAttack--;
            nextEnemy = enemyRate;
            enemyRate *= 0.8f;
            if (enemyRate < 1)
            {
                enemyRate = 1;
            }
            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnDistance;
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], transform.position + offset, Quaternion.identity);
        }
        if (countdown4SuperAttack <= 0)
        {
            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnDistance;
            Instantiate(SuperAttack, transform.position + offset, Quaternion.identity);
            countdown4SuperAttack = startingCountdown;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    float enemyRate = 5;
    float nextEnemy = 1;
    float spawnDistance = 20;
    public GameObject[] enemyPrefab;

    void Update()
    {
        nextEnemy -= Time.deltaTime;
        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;
            if (enemyRate < 1)
            {
                enemyRate = 1;
            }
            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnDistance;
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length-1)], transform.position + offset, Quaternion.identity);
        }
    }
}

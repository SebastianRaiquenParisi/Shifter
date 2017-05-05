using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    float enemyRate = 5;
    float nextEnemy = 1;
    float spawnDistance = 20; 
    public GameObject[] enemyPrefab;
	// Update is called once per frame
	void Update () {
        nextEnemy -= Time.deltaTime;
        if(nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;
            if(enemyRate < 2)
            {
                enemyRate = 2;
            }
            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnDistance;
            Instantiate(enemyPrefab[0], transform.position + offset, Quaternion.identity);
        }
	}
}

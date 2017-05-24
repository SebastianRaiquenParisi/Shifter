using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerLaser : MonoBehaviour {

    float enemyRate = 4;
    float nextEnemy = 1;
    float spawnDistance = 20;
    public GameObject[] enemyPrefab;
    public GameObject SuperAttack;
    public GameObject WeakPoint;
    public float countdown4SuperAttack = 2;
    public float countdown4WeakPoint = 6;
    float startingCountdown;
    float startingCountdownWeakPoint;

    private void Start()
    {
        startingCountdown = countdown4SuperAttack;
        startingCountdownWeakPoint = countdown4WeakPoint;
    }

    void Update()
    {
        nextEnemy -= Time.deltaTime;
        Vector3 offset = Random.onUnitSphere;
        offset.z = 0;
        offset = offset.normalized * spawnDistance;
        if (nextEnemy <= 0)
        {
            countdown4SuperAttack--;
            nextEnemy = enemyRate;
            enemyRate *= 0.8f;
            if (enemyRate < 1)
            {
                enemyRate = 1;
            }
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], transform.position + offset, Quaternion.identity);
        }
        if (countdown4SuperAttack <= 0)
        {
            countdown4WeakPoint--;
            
            Instantiate(SuperAttack, transform.position + offset, Quaternion.identity);
            countdown4SuperAttack = startingCountdown;
        }
        if (countdown4WeakPoint <= 0)
        {
            Instantiate(WeakPoint, transform.position + offset, Quaternion.identity);
            countdown4WeakPoint = startingCountdownWeakPoint;
        }
    }
}

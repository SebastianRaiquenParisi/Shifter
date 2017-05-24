using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerSwords : MonoBehaviour {
    float enemyRate = 3.5f;
    float nextEnemy = 1;
    float spawnDistance = 20;
    public GameObject[] enemyPrefab;
    public GameObject SuperAttack;
    public GameObject WeakPoint;
    public float countdown4SuperAttack = 5;
    public float countdown4WeakPoint = 3;
    float startingCountdownSuperAttack;
    float startingCountdownWeakPoint;

    private void Start()
    {
        startingCountdownSuperAttack = countdown4SuperAttack;
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
            enemyRate *= 0.9f;
            if (enemyRate < 2)
            {
                enemyRate = 2;
            }
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], transform.position + offset, Quaternion.identity);
        }
        if(countdown4SuperAttack <= 0)
        {
            countdown4WeakPoint--;
            Instantiate(SuperAttack, transform.position, Quaternion.identity);
            countdown4SuperAttack = startingCountdownSuperAttack;
        }
        if (countdown4WeakPoint <= 0)
        {
            Instantiate(WeakPoint, transform.position + offset, Quaternion.identity);
            countdown4WeakPoint = startingCountdownWeakPoint;
        }
    }
}

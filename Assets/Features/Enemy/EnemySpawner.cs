using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyPool enemyPool;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] Transform target;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        enemyPool = GetComponent<EnemyPool>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            timer = 0f;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        EnemyController enemy = enemyPool.Get();

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        enemy.transform.position = spawnPoint.position;

        enemy.Initialize(enemyPool, target);
    }
}

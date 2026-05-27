using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] EnemyController enemyPrefab;
    [SerializeField] int initialSpawn = 10;

    public Queue<EnemyController> pool = new Queue<EnemyController>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialSpawn; i++)
        {
            EnemyController enemy = Instantiate(enemyPrefab);
            enemy.gameObject.SetActive(false);
            pool.Enqueue(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EnemyController Get()
    {
        EnemyController enemy;

        if(pool.Count > 0)
        {
            enemy = pool.Dequeue();
        }
        else
        {
            enemy = Instantiate(enemyPrefab);
        }

        enemy.gameObject.SetActive(true);

        return enemy;
    }

    public void ReturnToPool(EnemyController enemy)
    {
        enemy.gameObject.SetActive(false);
        pool.Enqueue(enemy);
    }
}

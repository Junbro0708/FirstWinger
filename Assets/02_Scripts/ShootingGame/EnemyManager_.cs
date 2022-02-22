using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager_ : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyFactory;

    [SerializeField]
    private int poolSize = 10;

    GameObject[] enemyObjectPool;
    public Transform[] spawnPoints;

    float currentTime;
    
    float minTime = 0.5f;
    float maxTime = 1.5f;
    float createTime;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new GameObject[poolSize];
        for(int i = 0; i < poolSize; ++i)
        {
            GameObject enemy = Instantiate(EnemyFactory);
            enemyObjectPool[i] = enemy;
            enemy.SetActive(false);
        }
    }
    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            for(int i = 0; i < poolSize; ++i)
            {
                GameObject enemy = enemyObjectPool[i];
                if(enemy.activeSelf == false)
                {
                    enemy.SetActive(true);

                    int index = Random.Range(0, spawnPoints.Length);
                    enemy.transform.position = spawnPoints[index].position;
                    break;
                }
            }
            createTime = Random.Range(minTime, maxTime);
            currentTime = 0f;
        }
    }
}

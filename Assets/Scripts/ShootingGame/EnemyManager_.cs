using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager_ : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyFactory;

    float currentTime;
    
    float minTime = 1f;
    float maxTime = 5f;
    float createTime;

    private void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }
    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            GameObject enemy = Instantiate(EnemyFactory);
            enemy.transform.position = transform.position;
            currentTime = 0f;

            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}

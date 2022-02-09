using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager_ : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyFactory;

    float currentTime;
    float createTime = 1f;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            GameObject enemy = Instantiate(EnemyFactory);
            enemy.transform.position = transform.position;
            currentTime = 0f;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    EnemyFactory enemyFactory;

    List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GenerateEnemy(new Vector3(15, 0, 0));
        }
    }

    public bool GenerateEnemy(Vector3 position)
    {
        GameObject go = enemyFactory.Load(EnemyFactory.EnemyPath);
        if (!go)
        {
            Debug.LogError("GenerateEnemy error");
            return false;
        }

        go.transform.position = position;
        Enemy enemy = go.GetComponent<Enemy>();
        enemy.Appear(new Vector3(7, 0, 0));

        enemies.Add(enemy);
        return true;
    }
}

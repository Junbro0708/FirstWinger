using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public const string EnemyPath = "Prefabs/Enemy";

    Dictionary<string, GameObject> EnemyFileCache = new Dictionary<string, GameObject>();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Load(string resourcePath)
    {
        GameObject go = null;

        if (EnemyFileCache.ContainsKey(resourcePath))
        {
            go = EnemyFileCache[resourcePath];
        }
        else
        {
            go = Resources.Load<GameObject>(resourcePath);
            if (!go)
            {
                Debug.LogError("Load Error! path = " + resourcePath);
                return null;
            }

            EnemyFileCache.Add(resourcePath, go);
        }

        GameObject Instanced = Instantiate<GameObject>(go);
        return Instanced;
    }
}

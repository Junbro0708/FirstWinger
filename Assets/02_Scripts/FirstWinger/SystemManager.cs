using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    static SystemManager instance;

    static public SystemManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    Player player;

    public Player Hero
    {
        get
        {
            if (!player)
            {
                Debug.LogError("Main Player is not setted!");
            }

            return player;
        }
    }

    GamePointAccumulator gamePointAccumulator = new GamePointAccumulator();

    public GamePointAccumulator GamePointAccumulator
    {
        get 
        { 
            return gamePointAccumulator; 
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("System Manager Error! Singletone Error");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

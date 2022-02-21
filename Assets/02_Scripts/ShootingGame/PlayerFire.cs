using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletFactory;

    [SerializeField]
    private GameObject firePosition;

    [SerializeField]
    private int poolSize = 10;

    GameObject[] bulletObjectPool;

    private void Start()
    {
        bulletObjectPool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool[i] = bullet;
            bullet.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for(int i = 0; i < poolSize; i++)
            {
                GameObject bullet = bulletObjectPool[i];
                if(bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.transform.position;
                    break;
                }
            }
        }
    }
}

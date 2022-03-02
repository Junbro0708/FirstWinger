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

    public List<GameObject> bulletObjectPool;

    private void Start()
    {
        bulletObjectPool = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);

                bullet.transform.position = firePosition.transform.position;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private void Update()
    {
        Vector3 dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}

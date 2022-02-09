using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("h + " + h + " v +" + v);

        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime; //transform.Translate(dir * speed * Time.deltaTime); 이거랑 같은 의미
    }
}

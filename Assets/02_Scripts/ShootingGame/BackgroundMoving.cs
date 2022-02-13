using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 0.2f;

    MeshRenderer mat;

    private void Start()
    {
        mat = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Vector2 dir = Vector2.up;
        mat.material.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
        
        if(mat.material.mainTextureOffset.y > 1)
        {
            mat.material.mainTextureOffset = Vector2.zero;
        }
    }
}

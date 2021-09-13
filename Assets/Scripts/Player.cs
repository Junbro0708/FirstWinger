﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Vector3 moveVector = Vector3.zero;

    [SerializeField]
    float Speed;

    [SerializeField]
    BoxCollider boxCollider;

    [SerializeField]
    Transform mainBGQuadTranform;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateMove();
    }

    void UpdateMove()
    {
        if (moveVector.sqrMagnitude == 0)
            return;

        moveVector = AdjustMoveVector(moveVector);

        transform.position += moveVector;
    }

    public void ProcessInput(Vector3 moveDirection)
    {
        moveVector = moveDirection * Speed * Time.deltaTime;
    }

    Vector3 AdjustMoveVector(Vector3 moveVector)
    {
        Vector3 result = Vector3.zero;
        result = boxCollider.transform.position + moveVector;
        Debug.Log(boxCollider.center);

        if (result.x - boxCollider.size.x * 0.5f < -mainBGQuadTranform.localScale.x * 0.5f)
            moveVector.x = 0;
        if (result.x + boxCollider.size.x * 0.5f > mainBGQuadTranform.localScale.x * 0.5f)
            moveVector.x = 0;

        if (result.y - boxCollider.size.y * 0.5f < -mainBGQuadTranform.localScale.y * 0.5f)
            moveVector.y = 0;
        if (result.y + boxCollider.size.y * 0.5f > mainBGQuadTranform.localScale.y * 0.5f)
            moveVector.y = 0;

        return moveVector;
    }
}
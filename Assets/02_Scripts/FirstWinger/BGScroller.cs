﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BGScrollData
{
    public Renderer renderForScroll;
    public float Speed;
    public float OffsetX;
}

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    BGScrollData[] ScrollDatas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScroll();
    }

    void UpdateScroll()
    {
        for(int i = 0; i < ScrollDatas.Length; i++)
        {
            SetTextureOffset(ScrollDatas[i]);
        }
    }

    void SetTextureOffset(BGScrollData scrollData)
    {
        scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime;
        if (scrollData.OffsetX > 1) scrollData.OffsetX = scrollData.OffsetX % 1.0f;

        Vector2 Offset = new Vector2(scrollData.OffsetX, 0);

        scrollData.renderForScroll.material.SetTextureOffset("_MainTex", Offset);
    }
}

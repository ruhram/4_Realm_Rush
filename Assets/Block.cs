﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector2Int gridPos;

    const int gridSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
         Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
         Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

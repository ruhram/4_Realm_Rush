﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] Color ExploredColor;
    Vector2Int gridPos;
    public bool isExplored = false;
    public Block exploredFrom;
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
         Mathf.RoundToInt(transform.position.x / gridSize) ,
         Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    public void SetTopColor(Color color)
    {
        MeshRenderer TopMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        TopMeshRenderer.material.color = color;
    }
}

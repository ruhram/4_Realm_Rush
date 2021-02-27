﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFInder : MonoBehaviour
{
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlock();
    }

    private void LoadBlock()
    {
        var waypoints = FindObjectsOfType<Block>();
        foreach(Block waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            
            if (grid.ContainsKey(gridPos))//overlapping
            {
                Debug.LogWarning("Skipping Over lapping block" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
            
        }
        print(grid.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
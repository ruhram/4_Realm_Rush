﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFInder : MonoBehaviour
{
    [SerializeField] Block startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();
    Queue<Block> queue = new Queue<Block>();
    bool isRunning = true;
    Block searchCenter;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };
    // Start is called before the first frame update
    void Start()
    {
        LoadBlock();
        ColorStartAndEnd();
        PathFind();
        
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print("Searching From "+ searchCenter);
            HaltIfendFound();
            ExploreNeighbours();
        }
        print("Finished Path Finding");
    }

    private void HaltIfendFound()
    {
        if(searchCenter == endWaypoint)
        {
            print("End Way Point Has been Found");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            if (!isRunning) { break; }
            Vector2Int NeighbourCoordinates = searchCenter.GetGridPos() + direction;
            try
            {
                QueueNewNeighbour(NeighbourCoordinates);
            }
            catch
            {

            }
        }
    }

    private void QueueNewNeighbour(Vector2Int NeighbourCoordinates)
    {
        Block neighbour = grid[NeighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }else{ 
            
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
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

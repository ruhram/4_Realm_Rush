using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFInder : MonoBehaviour
{
    [SerializeField] Block startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.down
    };
    // Start is called before the first frame update
    void Start()
    {
        LoadBlock();
        ColorStartAndEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int ExploreCoordinate = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[ExploreCoordinate].SetTopColor(Color.blue);
            }
            catch
            {

            }
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

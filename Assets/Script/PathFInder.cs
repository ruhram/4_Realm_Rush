using System;
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
    List<Block> path = new List<Block>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

    public List<Block> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }

        return path;
        
        
    }

    private void CalculatePath()
    {
        LoadBlock();
        //ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void CreatePath()
    {
        SetAsPath(endWaypoint);
        Block previous = endWaypoint.exploredFrom;
        while(previous != startWaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }
        SetAsPath(startWaypoint);
        path.Reverse();
    }

    private void SetAsPath(Block Waypoint)
    {
        path.Add(Waypoint);
        Waypoint.isPlaceable = false;
    }
    private void BreadthFirstSearch()
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
            if(grid.ContainsKey(NeighbourCoordinates))
            {
                QueueNewNeighbour(NeighbourCoordinates);//if there aren't block
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

    /*private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }*/

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

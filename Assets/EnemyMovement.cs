﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        PathFInder pathfinder = FindObjectOfType<PathFInder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

   IEnumerator FollowPath(List<Block> path)
    {
        foreach(Block waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

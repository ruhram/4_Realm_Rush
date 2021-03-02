using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefabs;

    //create empty queue 
    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Block baseWaypoint)
    {
        //change queue size
        //var towers = FindObjectsOfType<Tower>();
        //int numTowers = towers.Length;
        int numTowers = towerQueue.Count;
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Block baseWaypoint)
    {
        var newTower = Instantiate(towerPrefabs, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        //put new tower on the queue
        towerQueue.Enqueue(newTower);
        //set the base waypoint
    }

    private void MoveExistingTower(Block baseWaypoint)
    {
        //take bottom tower of queue
        var oldTower = towerQueue.Dequeue();
        //set the placeable flags

        //set the base waypoint

        towerQueue.Enqueue(oldTower);
    }

   
}

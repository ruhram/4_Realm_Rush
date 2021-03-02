using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefabs;
    [SerializeField] Transform towerParentTransform;

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
        newTower.transform.parent = towerParentTransform.transform;
        baseWaypoint.isPlaceable = false;

        //set the base waypoint
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        //put new tower on the queue
        towerQueue.Enqueue(newTower);
        
    }

    private void MoveExistingTower(Block NewBaseWaypoint)
    {
        //take bottom tower of queue
        var oldTower = towerQueue.Dequeue();
        //set the placeable flags
        oldTower.baseWaypoint.isPlaceable = true; //free-up the block
        NewBaseWaypoint.isPlaceable = false;

        //set the base waypoint
        oldTower.baseWaypoint = NewBaseWaypoint;
        oldTower.transform.position = NewBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }

   
}

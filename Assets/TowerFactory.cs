using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefabs;
    // Start is called before the first frame update
    
    public void AddTower(Block baseWaypoint)
    {
        var towers = FindObjectsOfType<Tower>();
        int numTowers = towers.Length;
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private static void MoveExistingTower()
    {
        Debug.Log("Max Tower Reached");
    }

    private void InstantiateNewTower(Block baseWaypoint)
    {
        Instantiate(towerPrefabs, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
    }
}

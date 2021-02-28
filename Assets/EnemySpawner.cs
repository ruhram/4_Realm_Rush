using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float SecondBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeateadlySpawnEnemy());
    }

    IEnumerator RepeateadlySpawnEnemy()
    {
        while (true)
        {
            print("Spawned Enemy");
            yield return new WaitForSeconds(SecondBetweenSpawn);//wait a bit
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

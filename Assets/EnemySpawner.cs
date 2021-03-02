﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float SecondBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeateadlySpawnEnemy());
    }

    IEnumerator RepeateadlySpawnEnemy()
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform.transform;
            yield return new WaitForSeconds(SecondBetweenSpawn);//wait a bit
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

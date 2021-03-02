using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float SecondBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemy;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeateadlySpawnEnemy());
        spawnedEnemy.text = score.ToString();
    }

    IEnumerator RepeateadlySpawnEnemy()
    {
        while (true)
        {
            ScoreTextUpdate();
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform.transform;
            yield return new WaitForSeconds(SecondBetweenSpawn);//wait a bit
        }
    }

    private void ScoreTextUpdate()
    {
        score++;
        spawnedEnemy.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

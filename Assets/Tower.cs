using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Parameter of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 50f;
    [SerializeField] ParticleSystem ProjectileParticle;

    //State
    Transform TargetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (TargetEnemy)
        {
            objectToPan.LookAt(TargetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
        
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = Getclosest(closestEnemy, testEnemy.transform);
        }
        TargetEnemy = closestEnemy;
    }

    private Transform Getclosest(Transform transformA, Transform transformB)
    {
        var distoA = Vector3.Distance(transform.position, transformA.position);
        var distoB = Vector3.Distance(transform.position, transformB.position);

        if (distoA < distoB)
        {
            return transformA;
        }
        else
        {
            return transformB;
        }
    }

    private void FireAtEnemy()
    {
        float DistanceToEnemy = Vector3.Distance(TargetEnemy.transform.position, gameObject.transform.position);
        if(DistanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = ProjectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform TargetEnemy;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem ProjectileParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

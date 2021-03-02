using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float MovementPeriod = .5f;
    [SerializeField] ParticleSystem deathParticle;
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
            yield return new WaitForSeconds(MovementPeriod);
        }
        selfDestruct();
    }

    public void selfDestruct()
    {
        var vfx = Instantiate(deathParticle, transform.position, Quaternion.identity);
        vfx.Play();

        //destroy particle after delay
        var destroyDelay = vfx.main.duration;

        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

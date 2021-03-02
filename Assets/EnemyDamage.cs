using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collision;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints < 0)
        {
            var vfx = Instantiate(deathParticle, transform.position, Quaternion.identity);
            vfx.Play();
 
            //destroy particle after delay
            var destroyDelay = vfx.main.duration;

            Destroy(vfx.gameObject, destroyDelay);
            Destroy(gameObject);
        }
    }
    void ProcessHit()
    {
        hitPoints--;
        print("Current Hit Point" + hitPoints);
        hitParticle.Play();
    }
}

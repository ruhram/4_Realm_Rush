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
            Destroy(gameObject);
            print("Enemy Died");
        }
    }
    void ProcessHit()
    {
        hitPoints--;
        print("Current Hit Point" + hitPoints);
        hitParticle.Play();
    }
}

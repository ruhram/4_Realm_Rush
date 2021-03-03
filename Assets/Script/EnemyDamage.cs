using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collision;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] AudioClip EnemyDamageSFX;
    [SerializeField] AudioClip EnemyDeathSFX;

    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
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
            AudioSource.PlayClipAtPoint(EnemyDeathSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
    void ProcessHit()
    {
        hitPoints--;
        print("Current Hit Point" + hitPoints);
        hitParticle.Play();
        myAudioSource.PlayOneShot(EnemyDamageSFX);
    }
}

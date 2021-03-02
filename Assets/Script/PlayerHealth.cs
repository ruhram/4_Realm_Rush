using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 2;
    [SerializeField] Text Health;
    [SerializeField] AudioClip playerDamageSFX;

    private void Start()
    {
        Health.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        health -= healthDecrease;
        Health.text = health.ToString();
    }
}

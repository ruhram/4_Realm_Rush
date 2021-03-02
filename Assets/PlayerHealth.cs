using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 2;
    [SerializeField] Text Health;

    private void Start()
    {
        Health.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        Health.text = health.ToString();
    }
}

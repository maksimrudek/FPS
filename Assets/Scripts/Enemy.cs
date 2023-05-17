using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health health;
    public GameObject bloodParticles;
    private UnityEngine.AI.NavMeshAgent agent;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.onDamage.AddListener(OnDamage);
        health.onDamage.AddListener(OnDeath);
        
    }

    private void OnDamage()
    {
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
    }

    private void OnDeath()
    {
        float randomx = UnityEngine.Random.Range(-2f, 2f);
        float randomz = UnityEngine.Random.Range(-2f, 2f);
        transform.position = new Vector3(randomx, 1f, randomz);
    }
}

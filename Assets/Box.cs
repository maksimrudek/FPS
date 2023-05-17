using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.onDamage.AddListener(onDamage);
        health.onDamage.AddListener(onDeath);
    }

    

    private void onDamage()
    {
        print("moves a box a little bit");
    }

    private void onDeath()
    {
        print("spawn many rigidbody pieces");
    }
}

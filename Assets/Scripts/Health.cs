using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHp = 100;
    public int hp;

    public bool destroyOnDeath;

    public UnityEvent onDamage;
    public UnityEvent onDeath;

    public void Damage(int amount)
    {
        hp -= amount;
        onDamage.Invoke();
        if(hp <= 0) Die();

    }

    private void Die()
    {
        onDeath.Invoke();
        if (destroyOnDeath) Destroy(gameObject);
        hp = maxHp;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected int health;
    [SerializeField] protected float speed;

    public abstract void Move(Vector2 direction);

    public virtual void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
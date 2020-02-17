using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int HP = 5;
    public float speed = 40f;
    public int Damage = 5;
    public int exp = 1;
    public bool dead = false;
    public bool atac = false;
    public virtual void ResiveDamage(int damage)
    {
        HP = HP - damage;
        
    }

    public virtual void Die()
    {
        Destroy(gameObject, 2.0f);
    }
}

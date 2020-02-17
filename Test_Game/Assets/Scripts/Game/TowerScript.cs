using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerScript : Unit
{
    public int CountTowr = 0;
    private GameObject Tower;

    private Main mSkript;
    void Start()
    {
        Damage = 30;
        //GameObject Tower = Instantiate(Resources.Load("Tower1"), new Vector3(100f, -25f, 0f), Quaternion.identity) as GameObject;
        mSkript = Camera.main.GetComponent<Main>();
    }

    void CheckDed()
    {
        if (!dead && HP <= 0)
        {
            
            switch (CountTowr)
            {
                case 0:
                    {
                         Tower = Instantiate(Resources.Load("Tower2"), new Vector3(100f, -25f, 0f), Quaternion.identity) as GameObject;
                        break;
                    }
                case 1:
                    {
                         Tower = Instantiate(Resources.Load("Tower3"), new Vector3(100f, -25f, 0f), Quaternion.identity) as GameObject;
                        break;
                    }
                case 2:
                    {
                         Tower = Instantiate(Resources.Load("Tower4"), new Vector3(100f, -25f, 0f), Quaternion.identity) as GameObject;
                        break;
                    }
                default:
                    {
                        mSkript.GameOver = true;
                        break;
                    }
                
            }

           /* TowerScript ts = Tower.GetComponent<TowerScript>();
            ts.CountTowr = CountTowr + 1;*/
            Destroy(gameObject);
            dead = true;
            Die();
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        Unit unit = collider.GetComponent<Unit>();
        if (unit && (unit is MonsterScript))
        {
            unit.ResiveDamage(Damage);
            //ResiveDamage(unit.Damage);
        }
        CheckDed();
    }
}

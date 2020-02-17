using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Move,
    Atac,
    Die
}
public class MonsterScript : Unit
{
    private int stopAtac = 2;
    private float timer = 0f;

    private Animator animator;
    private Main mSkript;


    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        mSkript = Camera.main.GetComponent<Main>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && (unit is ArcherScript || unit is TowerScript))
        {
            atac = true;
            timer = 0f;
            state = MonsterState.Atac;
            unit.ResiveDamage(Damage);
        }
    }
    private MonsterState state
    {
        get { return (MonsterState)animator.GetInteger("sprite"); }
        set { animator.SetInteger("sprite", (int)value); }
    }
    void CheckVictory()
    {
        if(mSkript.Victory)
        {
            Die();
        }
    }
    void CheckDed()
    {
        if (!dead && HP <= 0)
        {
            dead = true;
            if (atac)
            {
                state = MonsterState.Atac;
            }else
            {
                state = MonsterState.Die;
            }
            mSkript.Exp += exp;

            Die();
        }
    }

    void move()
    {
        if (!dead && !atac)
        {
            state = MonsterState.Move;

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(100f, transform.position.y, 0f), speed * Time.deltaTime);
            if (transform.position.x == 90f)
            {
                //state = MonsterState.Die;
               // Die();
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(stopAtac < timer) atac = false;
        CheckDed();
        move();
    }
}

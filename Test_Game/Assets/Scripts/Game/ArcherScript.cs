using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArcherState
{
    Idel,
    Move,
    Shoot
}
public class ArcherScript : Unit
{

    //private float speed = 20f;
    //private int HP = 10;
    public int Levl = 0;

    new private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer sprite;
    Transform target;


    private Main mSkript;
    //private GameObject NewArrow;



    private ArcherState state
    {
        get { return (ArcherState)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        mSkript = Camera.main.GetComponent<Main>();
        mSkript.Levl = Levl;
    }
    void SetTarget()
    {

        Vector3 direction = Input.mousePosition / 10;
        if ((direction.x - 50 > -80) && (direction.x - 50 < 80) &&(direction.y - 55< 0) &&(direction.y - 55 > -55))
        {
            if (target) Destroy(target.gameObject);
            GameObject NewTarget = Instantiate(Resources.Load("Pointer"), new Vector3(direction.x - 50, direction.y - 45, 0f), Quaternion.identity) as GameObject;
            target = NewTarget.transform;
        }
    }
    void move()
    {
        state = ArcherState.Move;
        if (transform.position.x >= target.position.x)
        {
            sprite.flipX = false;
        }else
        {
            sprite.flipX = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position , speed*Time.deltaTime);
        if (transform.position == target.position)
        {
            Destroy(target.gameObject);
            
        }

    }

    void Shoot()
    {
        Vector3 direction = Input.mousePosition / 10;
        if ((direction.x - 50 > -50) && (direction.x - 50 < 50) && (direction.y - 55 < -10) && (direction.y - 55 > -55))
        {
            state = ArcherState.Shoot;
            
            switch (Levl)
            {
                case 1:
                    {
                      Instantiate(Resources.Load("Arrow"), transform.position, Quaternion.identity);
                    
                    break;
                }
                case 2:
                    {
                        Instantiate(Resources.Load("Arrow"), transform.position, Quaternion.identity);
                        Instantiate(Resources.Load("Arrow"), new Vector3(transform.position.x, transform.position.y +5f ,0f ), Quaternion.identity);
                        break;
                }
                case 3:
                    {
                          Instantiate(Resources.Load("Arrow"), new Vector3(transform.position.x, transform.position.y + 5f, 0f), Quaternion.identity) ;
                         Instantiate(Resources.Load("Arrow"), transform.position, Quaternion.identity);
                          Instantiate(Resources.Load("Arrow"), new Vector3(transform.position.x, transform.position.y - 5f, 0f), Quaternion.identity);
                        break;
                }
                default:
                    {

                    break;
                }

            }
            GameObject NewArrow = Instantiate(Resources.Load("Arrow"), transform.position, Quaternion.identity) as GameObject;
            
        }
    }

    void CheckDed()
    {
        if (!dead && HP <= 0)
        {
            dead = true;
            Die();
        }
    }
    void Update()
    {
        if (!dead)
        {
            CheckDed();
            state = ArcherState.Idel;
            if (Input.GetMouseButtonDown(0))
            {
                SetTarget();
                /*Vector3 direction = Input.mousePosition / 10;
                move(direction.x - 55, direction.y - 55);*/
            }
            if (target)
            {
                move();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Shoot();
            }
        }
    }

}

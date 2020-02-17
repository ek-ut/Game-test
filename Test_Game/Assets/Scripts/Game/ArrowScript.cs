using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private float speed = 40f;
    private float targetx = -90;
    private SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        //mSkript = Camera.main.GetComponent<Main>();
        
    }
    /*public bool SetTargetX(float xp)
    {
        targetx = xp;
        return true;
    }*/

        void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if(unit && unit is MonsterScript)
        {

            //Debug.Log("Попал");
            unit.ResiveDamage(1);
            Destroy(gameObject);
        }
    }

    
    void Move()

    {

        if (transform.position.x >= targetx)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        Vector3 tar = new Vector3(targetx, transform.position.y , 0f);
        transform.position = Vector3.MoveTowards(transform.position, tar, speed * Time.deltaTime);
        if(transform.position.x == targetx)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}

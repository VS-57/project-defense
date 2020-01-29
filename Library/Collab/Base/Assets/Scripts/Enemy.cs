using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public float enemySpeed = 1f;
    //public float enemyStoppingDistance;
    public float timer = 0;
    public int damage = 10;
    public int health = 100;

    public GameObject deathEffect;
    //private Transform target;

    //void Start()
    //{
    //    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    //}
    //void Update()
    //{
    //    if (Vector2.Distance(transform.position,target.position)>0)
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position,target.position,enemySpeed*Time.deltaTime);
    //    }
    //}

    public void OnTriggerStay2D(Collider2D hitinfo)
    {
        Debug.Log(hitinfo.name);
        PlayerMovement Player = hitinfo.GetComponent<PlayerMovement>();
        if (Player != null)
        {
            if (timer > 5)
            {
                Player.TakeDamage(damage);
                timer = 0;
            }
            timer += 0.1f;
        }
    }

        public void TakeDamageEnemy(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float timer = 0;
    public int damage = 10;
    public int health = 100;
    public GameObject coin;

    public Transform DropPoint;

    public GameObject deathEffect;


    public void OnTriggerEnter2D(Collider2D hitinfo)
    {

        PlayerMovement Player = hitinfo.GetComponent<PlayerMovement>();
        if (Player != null)
        {
            Player.TakeDamage(damage);
        }
    }

    
    public void OnTriggerStay2D(Collider2D hitinfo)
    {
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

    void DropCoin()
    {
        Instantiate(coin, DropPoint.position, DropPoint.rotation);
    }
    void Die()
    {
        DropCoin();
        Destroy(gameObject);
    }
}

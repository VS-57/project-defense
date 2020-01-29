﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    public void damagebuff(int a)
    {
        damage += a;
    }

    public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Enemy enemy = hitinfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamageEnemy(damage);
        }
        Destroy(gameObject);
    }
}

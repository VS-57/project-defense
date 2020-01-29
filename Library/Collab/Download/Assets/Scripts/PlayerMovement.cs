using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Joystick joystick;
    public Joystick joystick2;
    public Transform gunpoint;
    public GameObject deathEffect;

    public int lastmovex = 0;
    public int lastmovey = 0;
    public int rotateCal = 1;

    public float starthealth = 100;
    private float health;
    public int money = 0;

    [Header("Unity Stuff")]
    public Image healthbar;
    public Text scoreText;


    Vector2 movement;
    Vector2 direction;

    private void Start()
    {
        health = starthealth;
    }
    void Update()
    {
        movement.x = joystick.Horizontal * moveSpeed;
        movement.y = joystick.Vertical * moveSpeed;

        direction.x = joystick2.Horizontal;
        direction.y = joystick2.Vertical;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        gunside();
        score();
    }

    public void score()
    {
        scoreText.text = money.ToString();
    }

    public void TakeDamage(int damage){

        health -= damage;

        healthbar.fillAmount = health / starthealth;
        
        if(health < 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void gunside()
    {
        if (direction.x == -1 && lastmovex != -1)
        {
            lastmovex = -1;
            if (rotateCal == 1) { gunpoint.Rotate(0, 0, 180); }
            if (rotateCal == 2) { gunpoint.Rotate(0, 0, 0); }
            if (rotateCal == 3) { gunpoint.Rotate(0, 0, 90); }
            if (rotateCal == 4) { gunpoint.Rotate(0, 0, -90); }
            rotateCal = 2;
        }
        if (direction.x == 1 && lastmovex != 1)
        {
            lastmovex = 1;
            if (rotateCal == 1) { gunpoint.Rotate(0, 0, 0);}
            if (rotateCal == 2) { gunpoint.Rotate(0, 0, 180);}
            if (rotateCal == 3) { gunpoint.Rotate(0, 0, -90);}
            if (rotateCal == 4) { gunpoint.Rotate(0, 0, 90);}
            rotateCal = 1;

        }
        if (direction.y == 1 && lastmovey != 1)
        {
            lastmovey = 1;
            if (rotateCal == 1) { gunpoint.Rotate(0, 0, 90); }
            if (rotateCal == 2) { gunpoint.Rotate(0, 0, -90);}
            if (rotateCal == 3) { gunpoint.Rotate(0, 0, 0);  }
            if (rotateCal == 4) { gunpoint.Rotate(0, 0, 180);}
            rotateCal = 3;
        }

        if (direction.y == -1 && lastmovey != -1)
        {

            lastmovey = -1;
            if (rotateCal == 1) { gunpoint.Rotate(0, 0, -90); }
            if (rotateCal == 2) { gunpoint.Rotate(0, 0, 90); }
            if (rotateCal == 3) { gunpoint.Rotate(0, 0, 180); }
            if (rotateCal == 4) { gunpoint.Rotate(0, 0, 0); }
            rotateCal = 4;
        }

    }
}




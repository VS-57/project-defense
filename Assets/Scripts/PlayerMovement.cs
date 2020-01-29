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
    public float timer = 0;
    public float guntimer = 0.5f;

    public int money = 0;

    [Header("Unity Stuff")]
    public Image healthbar;
    public Text scoreText;

    public Transform Gun1;
    public Transform Gun2;
    public Transform Gun3;
    public Transform Gun4;

    public GameObject Rocket1;


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
        //Shoot();
        score();
    }

    public void Shoot()
        {

        if (direction.y != 0 || direction.x != 0)
        {
            timer += Time.deltaTime;
            if (timer > guntimer)
            {
                Instantiate(Rocket1, Gun1.position, Gun1.rotation);
                timer = 0;
            }
        }
        }
    public void Shoot4()
    {

        if (direction.y != 0 || direction.x != 0)
        {
            timer += Time.deltaTime;
            if (timer > guntimer)
            {
                Instantiate(Rocket1, Gun4.position, Gun4.rotation);
                timer = 0;
            }
        }
    }
    public void Shoot2()
    {

        if (direction.y != 0 || direction.x != 0)
        {
            timer += Time.deltaTime;
            if (timer > guntimer)
            {
                Instantiate(Rocket1, Gun2.position, Gun2.rotation);
                timer = 0;
            }
        }
    }
    public void Shoot3()
    {

        if (direction.y != 0 || direction.x != 0)
        {
            timer += Time.deltaTime;
            if (timer > guntimer)
            {
                Instantiate(Rocket1, Gun3.position, Gun3.rotation);
                timer = 0;
            }
        }
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
        if(direction.x == 1)
        {
            Shoot();
        }
        if (direction.x == -1)
        {
            Shoot3();
        }
        if (direction.y == 1)
        {
            Shoot2();
        }
        if (direction.y == -1)
        {
            Shoot4();
        }
    }

    public void movespeedbuff() {
        if (money > 19)
        {
            moveSpeed *= 1.1f;
            money -= 20;
        }
        
    }

    public void damagebuff(GameObject rocket1)
    {
        if (money > 19)
        {
            Bullet enemy = Rocket1.GetComponent<Bullet>();
            enemy.damagebuff(20);
            money -= 20;
        }
    }
}




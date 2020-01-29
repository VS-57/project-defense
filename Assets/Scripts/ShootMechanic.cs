using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMechanic : MonoBehaviour
{
    public Transform Gun;
    
    public GameObject Rocket1;


    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Shoot();
        }

    }
    public void Shoot()
    {
        Instantiate(Rocket1, Gun.position, Gun.rotation);
    }
}

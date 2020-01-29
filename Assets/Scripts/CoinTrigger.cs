using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public int coinvalue = 10;

    public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        PlayerMovement Player = hitinfo.GetComponent<PlayerMovement>();
        if (Player != null)
        {
            Player.money += coinvalue;
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * EnemyHurtPlayer, damit Gegner dem Palyer schaden zufügen
 */

public class EnemyHurtPlayer : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damage);
        }
    }
}

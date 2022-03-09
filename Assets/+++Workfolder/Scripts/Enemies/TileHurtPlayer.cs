using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * TileHurtPlayer, damit Puddles dem Palyer schaden zufügen
 */

public class TileHurtPlayer : MonoBehaviour
{
    public int damage;                                     // beinhaltet den Schaden, welcher vom Player angezogen wird

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damage);
        }
    }
}

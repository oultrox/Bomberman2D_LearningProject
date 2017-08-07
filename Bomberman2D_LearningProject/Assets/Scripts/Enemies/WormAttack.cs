using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAttack : MonoBehaviour {

    [SerializeField] private int damage;
    private Health playerHP;

    //basic collision method asking if what collided is an enemy.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHP = collision.gameObject.GetComponent<Health>();
            if (playerHP)
            {
                if (!playerHP.IsFlashing)
                {
                    playerHP.TakenDamage(damage);
                }
            }
        }
    }
}



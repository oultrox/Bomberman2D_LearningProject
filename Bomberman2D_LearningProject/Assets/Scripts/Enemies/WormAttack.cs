using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAttack : MonoBehaviour {

    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health hp = collision.gameObject.GetComponent<Health>();
            if (hp)
            {
                hp.TakenDamage(damage);
                Debug.Log("Supuestamente dañando.");
            }
        }
    }
}

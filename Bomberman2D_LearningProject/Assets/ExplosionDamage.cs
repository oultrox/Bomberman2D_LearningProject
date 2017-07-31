using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destructible"))
        {
            Destroy(collision.gameObject);
        }
    }
}

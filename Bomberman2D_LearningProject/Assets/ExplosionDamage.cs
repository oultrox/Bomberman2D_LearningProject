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
        else if(collision.CompareTag("Indestructible"))
        {
            Destroy(this.gameObject);
        }else if(collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}

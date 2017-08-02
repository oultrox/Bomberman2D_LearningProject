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
            else if (collision.CompareTag("Indestructible"))
            {
                Destroy(this.gameObject);
            }
            else
            {
                // Get the function to damage the the entity who has the Health Component.
                Health hp = collision.GetComponent<Health>();
                if (hp) // ask if exist 
                {
                    hp.TakenDamage(1);
                }
                
            }
    }
        
}

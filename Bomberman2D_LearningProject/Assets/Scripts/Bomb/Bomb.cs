using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bomb explosion algorythm method.
public class Bomb : MonoBehaviour {

    [SerializeField] private GameObject explosionPrefab;

    private BoxCollider2D hitbox;
    private void Awake()
    {
        hitbox = this.GetComponent<BoxCollider2D>();
    }
    private void OnDestroy()
    {
        GameManager.instance.CantBombas++;
        Vector2 posicionCentro = new Vector2(transform.position.x, transform.position.y);
        Instantiate(explosionPrefab, posicionCentro, Quaternion.identity);
        for (int i = 1; i <= GameManager.instance.NivelBomba; i++)
        {
            Vector2 posicionArriba = new Vector2(transform.position.x, transform.position.y - i);
            Vector2 posicionAbajo = new Vector2(transform.position.x, transform.position.y + i);
            Vector2 posicionIzquierda = new Vector2(transform.position.x - i, transform.position.y);
            Vector2 posicionDerecha = new Vector2(transform.position.x + i, transform.position.y);

            Instantiate(explosionPrefab, posicionArriba, Quaternion.identity);
            Instantiate(explosionPrefab, posicionAbajo, Quaternion.identity);
            Instantiate(explosionPrefab, posicionIzquierda, Quaternion.identity);
            Instantiate(explosionPrefab, posicionDerecha, Quaternion.identity);
        }
        
    }

    // the collider trick for maknig the bomb solid once the bomberman is out of its hitbox.
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.hitbox.isTrigger = false;
    }

    // collision that activates other bombs if they collide with another explosions of another bomb.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}

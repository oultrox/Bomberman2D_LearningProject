using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int nivelBomba;

    private BoxCollider2D hitbox;
    private void Awake()
    {
        hitbox = this.GetComponent<BoxCollider2D>();
    }
    private void OnDestroy()
    {
        BombDrop.cantidadBombas++;
        Vector2 posicionCentro = new Vector2(transform.position.x, transform.position.y);
        Instantiate(explosionPrefab, posicionCentro, Quaternion.identity);
        for (int i = 1; i <= nivelBomba; i++)
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.hitbox.isTrigger = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bomb explosion algorythm method.
public class Bomb : MonoBehaviour {

    [SerializeField] private GameObject explosionPrefab;
    private BoxCollider2D hitbox;

    //Variables for controlling the explosion expansion.
    private Collider2D[] hitColliders;
    private bool isUpSpawneable = true;
    private bool isDownSpawneable = true;
    private bool isLeftSpawneable = true;
    private bool isRightSpawneable = true;


    //-----------API Methods------------
    //Initialization.
    private void Awake()
    {
        hitbox = this.GetComponent<BoxCollider2D>();
    }

    //Explosion trigger
    private void OnDestroy()
    {
        //adds a bomb to the player's capacity for spawn bombs
        GameManager.instance.CantBombas++;

        //Spawns the middle explosion
        Vector2 posicionCentro = new Vector2(transform.position.x, transform.position.y);
        Instantiate(explosionPrefab, posicionCentro, Quaternion.identity);

        // Explosion up direction algorythm asking using OverlapCircleAll() for asking if that position there's a indestructible block, 
        // if not, it's spawneable, if yes, set's the boolean flag to false and the loop breaks;
        isUpSpawneable = true;
        for (int i = 1; i <= GameManager.instance.NivelBomba; i++)
        {
            Vector2 posicionArriba = new Vector2(transform.position.x, transform.position.y - i);
            hitColliders = Physics2D.OverlapCircleAll(posicionArriba, 0.1f);

            for (int j =0; j < hitColliders.Length; j++)
            {
                if (hitColliders[j].gameObject.CompareTag("Indestructible"))
                {
                    isUpSpawneable = false;
                }
            }
            if (isUpSpawneable)
            {
                Instantiate(explosionPrefab, posicionArriba, Quaternion.identity);
            }
            else
            {
                break;
            }
        }

        // Explosion down - same as above.
        isDownSpawneable = true;
        for (int i = 1; i <= GameManager.instance.NivelBomba; i++)
        {
            Vector2 posicionAbajo = new Vector2(transform.position.x, transform.position.y + i);
            hitColliders = Physics2D.OverlapCircleAll(posicionAbajo, 0.1f);

            for (int j = 0; j < hitColliders.Length; j++)
            {
                if (hitColliders[j].gameObject.CompareTag("Indestructible"))
                {
                    isDownSpawneable = false;
                }
            }
            if (isDownSpawneable)
            {
                Instantiate(explosionPrefab, posicionAbajo, Quaternion.identity);
            }
            else
            {
                break;
            }
        }

        // Explosion left
        isLeftSpawneable = true;
        for (int i = 1; i <= GameManager.instance.NivelBomba; i++)
        {

            Vector2 posicionIzquierda = new Vector2(transform.position.x - i, transform.position.y);
            hitColliders = Physics2D.OverlapCircleAll(posicionIzquierda, 0.1f);

            for (int j = 0; j < hitColliders.Length; j++)
            {
                if (hitColliders[j].gameObject.CompareTag("Indestructible"))
                {
                    isLeftSpawneable = false;
                }
            }
            if (isLeftSpawneable)
            {
                Instantiate(explosionPrefab, posicionIzquierda, Quaternion.identity);
            }
            else
            {
                break;
            }
        }

        // Explosion right
        isRightSpawneable = true;
        for (int i = 1; i <= GameManager.instance.NivelBomba; i++)
        {
            Vector2 posicionDerecha = new Vector2(transform.position.x + i, transform.position.y);
            hitColliders = Physics2D.OverlapCircleAll(posicionDerecha, 0.1f);

            for (int j = 0; j < hitColliders.Length; j++)
            {
                if (hitColliders[j].gameObject.CompareTag("Indestructible"))
                {
                    isRightSpawneable = false;
                }
            }
            if (isRightSpawneable)
            {
                Instantiate(explosionPrefab, posicionDerecha, Quaternion.identity);
            }
            else
            {
                break;
            }
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

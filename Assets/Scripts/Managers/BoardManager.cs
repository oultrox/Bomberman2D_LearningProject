using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates the map.
public class BoardManager : MonoBehaviour {
    
    public static BoardManager instance;

    [SerializeField] private GameObject pilar;
    [SerializeField] private GameObject bloque;
    [SerializeField] private GameObject[] enemies;

    [SerializeField] private int columnas; //15
    [SerializeField] private int filas;    //13
    [SerializeField] private float multiplicadorBloquesDestruibles;
    [SerializeField] private float multiplicadorEnemigos;

    private List<Vector2> mapaPosiciones = new List<Vector2>();
    
    //---------API Methods--------
    //Singleton creation
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    //Execution of the creation methods.
    void Start () 
    {
        MapeoPosiciones();
        InicializationPlayer();
        CrearPilares();
        CrearBloques();
        CrearEnemigos();
	}

    //Gets all the tiles of the map.
    private void MapeoPosiciones()
    {
        for (int x = 0; x < columnas; x++)
        {
            for (int y = 0; y < filas; y++)
            {
                mapaPosiciones.Add(new Vector2(x, y));
            }
        }
    }

    //Sets the player position, and deleting innecesary starting blocks.
    private void InicializationPlayer()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        mapaPosiciones.Remove(new Vector2(playerPos.x, playerPos.y));
        mapaPosiciones.Remove(new Vector2(playerPos.x + 1, playerPos.y));
        mapaPosiciones.Remove(new Vector2(playerPos.x, playerPos.y + 1));
        mapaPosiciones.Remove(new Vector2(playerPos.x, playerPos.y - 1));
    }

    //Creates the pillars based on mapaPosiciones, since it's the List that has all the tile positions.
    private void CrearPilares()
    {
        Transform pilares = new GameObject("Pilares").transform;
        pilares.transform.SetParent(this.transform);
        for (int x = -1; x < columnas + 1; x++)
        {
            for (int y = -1; y < filas + 1; y++) //Based on the columnas and filas values
            {
                if (y == -1 || x == -1 || y == filas || x == columnas) // ask is if on the edges.
                {
                    Instantiate(pilar, new Vector3(x, y), Quaternion.identity); // create the borders
                }
                else if (x % 2 != 0 && y % 2 != 0) // if the position of the loop index value it's even
                {
                    Instantiate(pilar, new Vector3(x, y), Quaternion.identity); //instantie the normal pillars.
                    mapaPosiciones.Remove(new Vector3(x, y)); //removes the occuped places from the map list.
                }
            }
        }
    }

    //Creates the destructible blocks with the same strategy using mapaPosiciones based
    //on a lowered quanity of possible tiles, avoiding creating blocks on every empty space.
    private void CrearBloques()
    {
        //divides the quantity of the blocks being spawned
        var cantidadBloques = (int) mapaPosiciones.Count / multiplicadorBloquesDestruibles;

        for (int x = 0; x < cantidadBloques; x++)
        {
            Instantiate(bloque, RandomPlacement(), Quaternion.identity);
        }
    }

    //Little randomValue method.
    Vector3 RandomPlacement()
    {
        int tempNumero = UnityEngine.Random.Range(0, mapaPosiciones.Count);
        Vector3 tempPosicion = mapaPosiciones[tempNumero];
        mapaPosiciones.Remove(tempPosicion);
        return tempPosicion;
    }

    //on the empty spaces creates the enemies, based on a lowered quanity of possible tiles, avoiding creating 
    //enemies on all the empty spaces.
    private void CrearEnemigos()
    {
        var cantidadBloques = (int)mapaPosiciones.Count / multiplicadorEnemigos;

        for (int x = 0; x < cantidadBloques; x++)
        {
            Instantiate(enemies[0], RandomPlacement(), Quaternion.identity);
        }
    }
}

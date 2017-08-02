using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    
    public static BoardManager instance;
    //15 x 13 pilares
    [SerializeField] private GameObject pilar;
    [SerializeField] private GameObject bloque;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int columnas; //15
    [SerializeField] private int filas;    //13
    [SerializeField] private float multiplicadorBloquesDestruibles;
    [SerializeField] private float multiplicadorEnemigos;
    private List<Vector2> mapaPosiciones = new List<Vector2>();

    private void Awake()
    {
        //Singleton creation
        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start () {
        
        MapeoPosiciones();
        InicializationPlayer();
        CrearPilares();
        CrearBloques();
        CrearEnemigos();
	}

    private void CrearEnemigos()
    {
        var cantidadBloques = (int)mapaPosiciones.Count / multiplicadorEnemigos;

        for (int x = 0; x < cantidadBloques; x++)
        {
            Instantiate(enemies[0], RandomPlacement(), Quaternion.identity);
        }
    }

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

    private void InicializationPlayer()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        mapaPosiciones.Remove(new Vector2(playerPos.x, playerPos.y));
        mapaPosiciones.Remove(new Vector2(playerPos.x + 1, playerPos.y));
        mapaPosiciones.Remove(new Vector2(playerPos.x, playerPos.y + 1));
        mapaPosiciones.Remove(new Vector2(playerPos.x, playerPos.y - 1));
    }

    private void CrearPilares()
    {
        Transform pilares = new GameObject("Pilatres").transform;
        pilares.transform.SetParent(this.transform);
        for (int x = -1; x < columnas + 1; x++)
        {
            for (int y = -1; y < filas + 1; y++)
            {
                if (y == -1 || x == -1 || y == filas || x == columnas)
                {
                    Instantiate(pilar, new Vector3(x, y), Quaternion.identity);
                }
                else if (x % 2 != 0 && y % 2 != 0)
                {
                    Instantiate(pilar, new Vector3(x, y), Quaternion.identity);
                    mapaPosiciones.Remove(new Vector3(x, y));
                }
            }
        }
    }

    private void CrearBloques()
    {
        var cantidadBloques = (int) mapaPosiciones.Count / multiplicadorBloquesDestruibles;

        for (int x = 0; x < cantidadBloques; x++)
        {
            Instantiate(bloque, RandomPlacement(), Quaternion.identity);
        }
    }
    Vector3 RandomPlacement()
    {
        int tempNumero = UnityEngine.Random.Range(0, mapaPosiciones.Count);
        Vector3 tempPosicion = mapaPosiciones[tempNumero];
        mapaPosiciones.Remove(tempPosicion);
        return tempPosicion;
    }

    

}

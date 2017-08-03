using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private int cantItems;
    //Power-ups
    private int cantBombasInstanciables;
    [SerializeField] private int cantMaxBombas;
    [SerializeField] private float playerSpeed;
    [SerializeField] private int nivelBomba;
    private Health playerHp;
    private void Awake()
    {
        //Singleton creation
        if (instance == null)
        {
            instance = this;
        }else if(instance!= this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void PossibleItemDrop(Transform target)
    {
        if (cantItems > 0)
        {
            //extendible con una cantidad estática de cuantos items se pueden spawnear en el nivel. todo vía el GameManager.
            if ((int)UnityEngine.Random.Range(0, 3) == 0)
            {
                Instantiate(instance.itemPrefabs[RandomValue()], target.transform.position, Quaternion.identity);
                cantItems--;
            }
        }
        
    }

    private int RandomValue()
    {
     return UnityEngine.Random.Range(0, itemPrefabs.Length);
    }

    public bool PuedeColocarBomba()
    {
        return CantBombas > 0;
    }

    public void AddCantidadBombas()
    {
        CantBombas += instance.CantMaxBombas;
        CantMaxBombas = 0;
    }

    public void AddHealth(int number)
    {
        playerHp.Life += number;
    }

    public int CantBombas
    {
        get
        {
            return cantBombasInstanciables;
        }

        set
        {
            cantBombasInstanciables = value;
        }
    }

    public float PlayerSpeed
    {
        get
        {
            return playerSpeed;
        }

        set
        {
            playerSpeed = value;
        }
    }

    public int NivelBomba
    {
        get
        {
            return nivelBomba;
        }

        set
        {
            nivelBomba = value;
        }
    }

    public int CantMaxBombas
    {
        get
        {
            return cantMaxBombas;
        }

        set
        {
            cantMaxBombas = value;
        }
    }

}

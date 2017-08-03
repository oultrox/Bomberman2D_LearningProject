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
    [SerializeField] private int playerHealth;

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

    public void PossibleItemDrop(Transform target)
    {
        //extendible con una cantidad estática de cuantos items se pueden spawnear en el nivel. todo vía el GameManager.
        if ((int)Random.Range(0, 3) == 0)
        {
            Instantiate(instance.itemPrefabs[0], target.transform.position, Quaternion.identity);
        }
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

    public int PlayerHealth
    {
        get
        {
            return playerHealth;
        }

        set
        {
            playerHealth = value;
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

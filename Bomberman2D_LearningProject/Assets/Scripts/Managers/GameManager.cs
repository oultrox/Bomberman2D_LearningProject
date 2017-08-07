using UnityEngine.SceneManagement;
using UnityEngine;

//Manages most of the match values and components of the player itself, in a general way.
public class GameManager : MonoBehaviour {

    public static GameManager instance;
    
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private int cantItems;

    //Power-ups variables
    private int cantBombasInstanciables;
    [SerializeField] private int cantMaxBombas;
    [SerializeField] private float playerSpeed;
    [SerializeField] private int nivelBomba;
    private Health playerHp;

    //------API methods------
    //Singleton creation
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }else if(instance!= this)
        {
            Destroy(this.gameObject);
        }
    }
    //Getting the component of the player health in order to execute related operations.
    private void Start()
    {
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    private void Update()
    {
        if (playerHp.Life <=0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    //Random drop for the items using the target as the position to spawn it.
    public void PossibleItemDrop(Transform target)
    {
        if (cantItems > 0)
        {
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

    //Assign bombs to the player quantity and resets the assigner variable CantMaxBombas.
    public void AddCantidadBombas()
    {
        CantBombas += instance.CantMaxBombas;
        CantMaxBombas = 0;
    }

    public void AddHealth(int number)
    {
        playerHp.Life += number;
    }

    //Properties - Getters and setters.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField] private int powerUpType;

    //---------API methods---------
    //Just ask if it collided with the player, assign the power up and destroy this object because no longer is useful.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AssignPowerUp();
            Destroy(gameObject);
        }
    }

    //---------Custom methods---------
    //Assigns the properties of the player depending of the power-up type.
    private void AssignPowerUp()
    {
        switch (powerUpType)
        {
            case 1:
                GameManager.instance.CantMaxBombas++;
                GameManager.instance.AddCantidadBombas();
                break;
            case 2:
                GameManager.instance.NivelBomba++;
                break;
            case 3:
                GameManager.instance.PlayerSpeed++;
                break;
            case 4:
                GameManager.instance.AddHealth(1);
                break;
            default:
                break;
        }
    }
}


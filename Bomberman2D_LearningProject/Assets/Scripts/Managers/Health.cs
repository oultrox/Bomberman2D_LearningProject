using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generic component that it's implemented on every object that could die by being destroyed.
public class Health : MonoBehaviour {

    [SerializeField] private int life;
    [SerializeField] private bool isPlayer;

    // Method to damage the object.
    public void TakenDamage(int damage)
    {
        life -= damage;
        if (life <= 0 && this)
        {
            if (isPlayer)
                this.gameObject.SetActive(false);
            else
                Destroy(gameObject);
        }
    }

    //Properties - getters and setters.
    public int Life
    {
        get
        {
            return life;
        }

        set
        {
            life = value;
        }
    }
}

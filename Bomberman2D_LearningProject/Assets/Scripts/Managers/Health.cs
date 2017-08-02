using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] private int life;
    [SerializeField] private bool isPlayer;

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
}

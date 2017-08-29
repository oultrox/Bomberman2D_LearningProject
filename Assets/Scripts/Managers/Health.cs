using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generic component that it's implemented on every object that could die by being destroyed.
public class Health : MonoBehaviour {

    [SerializeField] private int life;
    [SerializeField] private bool isPlayer;
    [SerializeField] private int flashingDuration;
    private SpriteRenderer sprite;
    private bool isFlashing;

    //-----API methods------
    public void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        isFlashing = false;
    }

    //-----Custom methods-----
    // Method to damage the object.
    public void TakenDamage(int damage)
    {
        if (!isFlashing)
        {
            life -= damage;
            if (life <= 0 && this)
            {
                if (isPlayer)
                    this.gameObject.SetActive(false);
                else
                    Destroy(gameObject);
            }
            else
            {
                StartCoroutine(Flashing());
            }
        }
        
    }

    //Simple flashing corroutine.
    IEnumerator Flashing()
    {
        isFlashing = true;
        for (int i = 0; i < flashingDuration; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        isFlashing = false;
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

    public bool IsFlashing
    {
        get
        {
            return isFlashing;
        }

        set
        {
            isFlashing = value;
        }
    }
}

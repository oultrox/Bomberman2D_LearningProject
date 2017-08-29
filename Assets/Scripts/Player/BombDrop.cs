using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour {

    [SerializeField] private GameObject bomb;
    private Vector2 pos;
    private Collider2D[] hitColliders;

    //Initialization, we set initial the bombs quantity.
    private void Start()
    {
        GameManager.instance.AddCantidadBombas();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.PuedeColocarBomba())
        {
            
            pos = this.transform.position;
            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);
            hitColliders = Physics2D.OverlapCircleAll(pos, 0.1f);
            if ((hitColliders.Length <= 1)) // If you don't have someone with a collider here
            {
                GameManager.instance.CantBombas--;
                Instantiate(bomb, pos, Quaternion.identity); // spawn the bomb.
            }
            
        }
	}

}

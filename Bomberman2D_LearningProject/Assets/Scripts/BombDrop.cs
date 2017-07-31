using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour {

    [SerializeField] private GameObject bomb;
    private Vector2 pos;
    private int cantidadBombas = 5;
    [SerializeField] private int cantMaxBombas;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && PuedeColocarBomba())
        {
            cantidadBombas--;
            pos = this.transform.position;
            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);
            Instantiate(bomb, pos, Quaternion.identity);
        }
	}

    bool PuedeColocarBomba()
    {
        return cantidadBombas > 0;
    }
}

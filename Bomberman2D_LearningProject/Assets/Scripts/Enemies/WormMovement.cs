using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves the worm along the map with linecasting.
public class WormMovement : MonoBehaviour {

    [SerializeField] private float speed;

    //-----------API methods---------------
    // Use this for initialization
    //Initializes and set the invoke every x seconds.
	void Start ()
    {
        InvokeRepeating("ChangeDir", 0.5f, 0.5f);
	}

    //-----------Custom methods-----------
    //Random value method
    private Vector2 Randir()
    {
        int r = Random.Range(-1, 2);
        return (Random.value < 0.5) ? new Vector2(r, 0) : new Vector2(0, r);
    }

    //Cast a line from the worm position to the position where the worm wanted to move, asking if there's something there,
    //If not, he will move into that position.
    private bool IsValid(Vector2 dir)
    {
        Vector2 pos = transform.position;

        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);

        return (hit.collider.gameObject == gameObject);
    }

    //The movement method applying the IsValid() return method.
    private void ChangeDir()
    {
        Vector2 dir = Randir();

        if (IsValid(dir))
        {
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            GetComponent<Animator>().SetFloat("moveX", (int)dir.x);
            GetComponent<Animator>().SetFloat("moveY", (int)dir.y);
        }
    }
}

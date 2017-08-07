using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves the worm along the map with linecasting.
public class WormMovement : MonoBehaviour {

    [SerializeField] private float speed;
    private Vector2 dir;
    private Rigidbody2D wormHitbox;
    private Animator wormAnimator;
    private Vector2 validPosition;
    private RaycastHit2D hit;
    private int rand;
    //-----------API methods---------------
    // Use this for initialization
    //Initializes and set the invoke every x seconds.
	void Start ()
    {
        wormAnimator = this.GetComponent<Animator>();
        wormHitbox = this.GetComponent<Rigidbody2D>();

        InvokeRepeating("ChangeDir", 0.5f, 0.5f);
	}

    //-----------Custom methods-----------
    //Random value method
    private Vector2 Randir()
    {
        rand = Random.Range(-1, 2);
        return (Random.value < 0.5) ? new Vector2(rand, 0) : new Vector2(0, rand);
    }

    //Cast a line from the worm position to the position where the worm wanted to move, asking if there's something there,
    //If not, he will move into that position.
    private bool IsValid(Vector2 dir)
    {
        validPosition = transform.position;

        hit = Physics2D.Linecast(validPosition + dir, validPosition);

        return (hit.collider.gameObject.Equals(gameObject));
    }

    //The movement method applying the IsValid() return method.
    private void ChangeDir()
    {
        dir = Randir();

        if (IsValid(dir))
        {
            wormHitbox.velocity = dir * speed;
            wormAnimator.SetFloat("moveX", (int)dir.x);
            wormAnimator.SetFloat("moveY", (int)dir.y);
        }
    }
}

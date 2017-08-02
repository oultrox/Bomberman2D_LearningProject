using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Animator anim;
    private Vector3 movement;
    private Rigidbody2D playerRigidBody;

    private float h;
    private float v;
    [SerializeField] private float speed;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        this.playerRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
         h = Input.GetAxisRaw("Horizontal");
         v = Input.GetAxisRaw("Vertical");
        if (h != 0f || v != 0f)
        {
            Move();
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
       
	}

    private void Move()
    {
        movement.x = h;
        movement.y = v;
        movement.z = 0f;
        movement = movement.normalized * speed * Time.deltaTime;
        this.playerRigidBody.MovePosition(transform.position + movement);
        anim.SetFloat("inputX", h);
        anim.SetFloat("inputY", v);
    }
}

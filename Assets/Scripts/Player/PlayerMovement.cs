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

    //---------API methods---------
    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        this.playerRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame, getting the axis's inputs to the float variables and askig if it's moving 
    // set the animator bool variable to true in order to execute the moving tree state machine.
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

    //---------Custom methods---------
    //Move method using the axis as floats, getting the direction based on those axis, and then applying playerRigidBody.MovePosition()
    //with the actual position + the movement vector with the speed value from the game manager. 
    private void Move()
    {
        movement.x = h;
        movement.y = v;
        movement.z = 0f;
        movement = movement.normalized * GameManager.instance.PlayerSpeed * Time.deltaTime;
        this.playerRigidBody.MovePosition(transform.position + movement);
        anim.SetFloat("inputX", h);
        anim.SetFloat("inputY", v);
    }
}

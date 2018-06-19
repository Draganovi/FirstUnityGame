using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D playerRB;
    private SpriteRenderer playerRenderer;
    private Animator animator;

    private bool facingRight = false;

    //move
    public float maxSpeed;
    

	// Use this for initialization
	void Start () {
        this.playerRB = GetComponent<Rigidbody2D>();
        this.playerRenderer = GetComponent<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !facingRight)// pressing right or D 
        {
            Flip();
        }
        else if (move < 0 && facingRight)// pressing left or A
        {
            Flip();
        }

        this.playerRB.velocity = new Vector2(move * this.maxSpeed, playerRB.velocity.y);
        this.animator.SetFloat("MoveSpeed", Math.Abs(move));

    }

    private void Flip()
    {
        this.facingRight = !this.facingRight;
        this.playerRenderer.flipX = !this.playerRenderer.flipX;
    }
}

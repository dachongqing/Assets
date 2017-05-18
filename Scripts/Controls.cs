using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour,Character
{
    public Rigidbody2D rb;
    public float movespeed;

    public bool moveright;
    public bool moveleft;

    public float jumpheight;

    public Transform groundCheck;

    public float groundCheckRadius;

    public LayerMask whatIsGround;

    private bool onGround;

    public int crystals;

    public bool waitPlayer;

    private bool roundOver;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitPlayer = true;
        this.roundOver = false;

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.Space) && this.onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpheight);

        }


        if (moveright)
        {
            Debug.Log("touch right b");
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        if (moveleft)
        {
            Debug.Log("touch left b");
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }

        if (this.crystals == 3)
        {
            //Debug.Log("going to level3 scene");
            // SceneManager.LoadSceneAsync("level3");

            Debug.Log("i done this round");
            this.roundOver = true;
        }
    }

    private void FixedUpdate()
    {
        this.onGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
    }

    public bool isDead()
    {
        return false;
    }

    public bool isPlayer()
    {
        return true;
    }

    public bool isWaitPlayer()
    {
        return this.waitPlayer;
    }

    public bool isRoundOver()
    {
        return this.roundOver;
    }

    public void roundStart()
    {
        //do nothing
    }

    public String getName() {
        return "Player"; 
    }

	////////////
	/// 
}

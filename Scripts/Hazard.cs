using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour,Character {

    private Controls player;

    public Transform start;

    public GameObject Explode;

    private bool roundOver;

    // Use this for initialization
    void Start () {
        this.player = FindObjectOfType<Controls>();
        this.roundOver = false;

    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
           // Instantiate(Explode, player.transform.position, player.transform.rotation);
         
           // player.transform.position = start.position;
            StartCoroutine("respawndelay");
        }
    }

    public IEnumerator waitAIMove()
    {
        Debug.Log("AI cal ... ... ...");
        //  player.enabled = false;
        //  player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //   player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(10);
      //  player.GetComponent<Renderer>().enabled = true;
     //  player.enabled = true;
         //this.roundOver = true;
    }

    public IEnumerator respawndelay()
    {
        Instantiate(Explode, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(2);
        player.crystals = 0;
        player.transform.position = start.position;
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;
    }

    public bool isDead()
    {
        return false;
    }

    public bool isPlayer()
    {
        return false;
    }

    public bool isWaitPlayer()
    {
        return false;
    }

    public void roundStart()
    {
        Debug.Log("it's AI show time");
        Debug.Log("AI cal ... ... ...");
    }

    public bool isRoundOver()
    {
        return roundOver;
    }

    public String getName()
    {
        return "AI";
    }
}

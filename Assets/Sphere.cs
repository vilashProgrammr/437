using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D myScriptsRigidbody2D;
    public float ballsInitialVelocity = 800f;
    private bool ballInPlay = false;
    private Rigidbody2D rb;
    private Transform parentTranform;
    public GameManager gm;
    public Button play;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        parentTranform = transform.parent;
        gm = GameManager.instance;
    }
  
	
	// Update is called once per frame
	void FixedUpdate () {       
        if (Input.touchCount > 0 && ballInPlay == false)
        {
            Touch touch = Input.GetTouch(0);
            transform.parent = null;
            rb.isKinematic = false;
            ballInPlay = true;
            rb.AddForce(new Vector3(ballsInitialVelocity/2, ballsInitialVelocity/2, 0));
        }
        
        else
            if (Input.GetKey(KeyCode.UpArrow) && ballInPlay == false)
        {
            transform.parent = null;
            rb.isKinematic = false;
            ballInPlay = true;
            rb.AddForce(new Vector3(ballsInitialVelocity/1.4f, ballsInitialVelocity/1.4f, 0));
        }
        else
            if (ballInPlay == true) {
            }
    
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("bricks OnCollisionEnter2D" + col);
        if (col.gameObject.tag == "DeathFloor")
        {
            ballInPlay = false;
            rb.isKinematic = true;
   
            GameManager.instance.decreaseLives();
            //transform.parent = GameObject.Find("Slider").transform;
            rb.GetComponent<Transform>().SetParent(parentTranform);         
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(parentTranform.position.x,parentTranform.position.y+0.52f,0);
       
        }

    }
}

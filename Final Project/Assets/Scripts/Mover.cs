using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mover : MonoBehaviour
{
     public float speed;

     private Rigidbody rb;
     private gameController gameController;
     public bool normal;
     public bool hard;
     public bool timed;

     void Start()
    {
      GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		    if (gameControllerObject != null)
		    {
		    	gameController = gameControllerObject.GetComponent <gameController>();
		    }
		    if (gameController == null)
		    {
		    	Debug.Log ("Cannot find 'GameController' script");
        } 
        rb = GetComponent<Rigidbody>();
        speed = gameController.speed;
        rb.velocity = transform.forward * speed;
     }
     void Update()
     {
       if (gameController.won == true)
       {
         Destroy(gameObject);
       }
     }
}

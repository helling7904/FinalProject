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
          rb = GetComponent<Rigidbody>();
          rb.velocity = transform.forward * speed;
          GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <gameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
          }
     }
     void Update()
     {
          if (gameController.normal == true)
        {
            speed = -5.0f;
        }
          if (gameController.timed == true)
        {
            speed = -5.0f;
        }
          if (gameController.hard == true)
        {
            speed = -10.0f;
        }
        if (gameController.won == true)
        {
            Destroy(gameObject);
        }
     }
}

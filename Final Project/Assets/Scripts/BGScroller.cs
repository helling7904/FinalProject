using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;
    private gameController gameController;
    public bool won;
    public bool normal;
     public bool hard;
     public bool timed;

    private Vector3 startPosition;

    void Start () 
    {
        startPosition = transform.position;
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


    void Update ()
    {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        if (gameController.won == true)
        {
            scrollSpeed = -20.25f;
        }
        if (gameController.hard == true)
        {
            scrollSpeed = -5.25f;
        }
        if (gameController.timed == true)
        {
            scrollSpeed = -0.25f;
        }
        if (gameController.normal == true)
        {
            scrollSpeed = -0.25f;
        }
    }
}

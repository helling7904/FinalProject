using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pSpeedUp : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    private gameController gameController;
    public bool won;
    public bool normal;
     public bool hard;
     public bool timed;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
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
        var main = ps.main;
        main.simulationSpeed = hSliderValue;
        if (gameController.won == true)
        {
            hSliderValue = 100.0f;
        }
        if (gameController.hard == true)
        {
            hSliderValue = 25.0f;
        }
        if (gameController.timed == true)
        {
            hSliderValue = 1.0f;
        }
        if (gameController.normal == true)
        {
            hSliderValue = 1.0f;
        }
        
    }

    void OnGUI()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(0, 0, 0, 0), hSliderValue, 0.0F, 5.0F);
    }
}

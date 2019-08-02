using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByBoundary : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public bool won;
	private gameController gameController;
   void OnTriggerExit (Collider other) 
	{
		Destroy(other.gameObject);
	}
}

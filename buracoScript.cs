using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buracoScript : MonoBehaviour {

	public GameObject carroca;
	private CarrocaScript carrocascr;

	void Start () {
		carrocascr = carroca.GetComponent<CarrocaScript> ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerExit2D(Collider2D hit)
	{
		carrocascr.rodaquebrada++;
	}
}

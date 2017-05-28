using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaibater : MonoBehaviour {

	public GameObject carro;
	private CarroScript carroScr;
	private float desaceleração;

	void Start () {
		carroScr = carro.GetComponent<CarroScript>();
	}

	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D hit)
	{
		carroScr.StopMeNow = false;
	}
}

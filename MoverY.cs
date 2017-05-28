using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverY : MonoBehaviour {

	public GameObject carroca;

	public void OnTriggerEnter2D(Collider2D hit){
		carroca.GetComponent<CarrocaScript>().speed = "PraFrente";
	}
	void OnTriggerExit2D(Collider2D hit){
		carroca.GetComponent<CarrocaScript>().speed = "Parado";
	}
}

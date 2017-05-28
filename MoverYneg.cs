using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverYneg : MonoBehaviour {

	public GameObject carroca;

	public void OnTriggerEnter2D(Collider2D hit){
		carroca.GetComponent<CarrocaScript>().speed = "PraTras";
	}
	void OnTriggerExit2D(Collider2D hit){
		carroca.GetComponent<CarrocaScript>().speed = "Parado";
	}
}

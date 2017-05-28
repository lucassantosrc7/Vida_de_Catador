﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverXneg : MonoBehaviour {

	public GameObject carroca;

	public void OnTriggerEnter2D(Collider2D hit){
		carroca.GetComponent<CarrocaScript>().rotate = "PraEsquerda";
	}
	void OnTriggerExit2D(Collider2D hit){
		carroca.GetComponent<CarrocaScript>().rotate = "Parado";
	}
}

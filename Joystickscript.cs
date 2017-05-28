using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using System;
using UnityEngine;

public class Joystickscript : MonoBehaviour {

	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;
	public GameObject BackGroud;

	//Movimento Circular
	private Vector2 meio;
	private Vector2 bolinha;

	private float distanciaX;
	private float distanciaY;
	private float circulo;
	public float raio;

	// Update is called once per frame
	void Update () {
		
		meio = BackGroud.transform.position;

		distanciaX = Mathf.Abs( meio.x -transform.position.x);
		distanciaY = Mathf.Abs( meio.y - transform.position.y);

		circulo = Mathf.Pow (distanciaX, 2) + Mathf.Pow (distanciaY, 2);


		if (circulo < raio) {
			bolinha = transform.position;
		} else {
			Vector2 bolinha2;
			bolinha2.x = transform.position.x - bolinha.x;
			bolinha2.y = transform.position.y - bolinha.y;
			transform.Translate (new Vector2 ((bolinha2.x * -1), (bolinha2.y * -1)));
		}
	}

	void OnEnable (){
		GetComponent<ReleaseGesture> ().Released += Zera;
	}

	void Zera( object sender, EventArgs e){
		transform.position = new Vector3 (BackGroud.transform.position.x, BackGroud.transform.position.y);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semaforoscript : MonoBehaviour {
	public GameObject sinal1;
	public GameObject sinal2;
	public GameObject Vermelho1;
	public GameObject Amarelo1;
	public GameObject Vermelho2;
	public GameObject Amarelo2;

	private float temporizador;

	private bool trocar = false;
	private string _semaforo1;
	private string _semaforo2;

	void Start () {
		_semaforo1 = "vermelho";
		_semaforo2 = "verde";
		StartCoroutine (Semaforo ());
		StartCoroutine (Semaforo2 ());
		//coliiders
		Vermelho1.active = false;
		Amarelo1.active = false;
		Vermelho2.active = false;
		Amarelo2.active = false;
	}
	
	// Update is called once per frame
	void Update () {
		//print(temporizador + " tempo");
		temporizador = Time.time;

		if (trocar) {
			StartCoroutine (Semaforo ());
			StartCoroutine (Semaforo2 ());
			trocar = false;
		}

		if (_semaforo1 == "verde") {
			sinal1.GetComponent<Renderer> ().material.color = Color.green;
			Vermelho1.active = false;
			Amarelo1.active = false;
		}
		if (_semaforo1 == "vermelho") {
			sinal1.GetComponent<Renderer> ().material.color = Color.red;
			Vermelho1.active = true;
			Amarelo1.active = false;
		}
		if (_semaforo1 == "amarelo") {
			sinal1.GetComponent<Renderer> ().material.color = Color.yellow;
			Vermelho1.active = false;
			Amarelo1.active = true;
		}
		if (_semaforo2 == "verde") {
			sinal2.GetComponent<Renderer> ().material.color = Color.green;
			Vermelho2.active = false;
			Amarelo2.active = false;
		}
		if (_semaforo2 == "vermelho") {
			sinal2.GetComponent<Renderer> ().material.color = Color.red;
			Vermelho2.active = true;
			Amarelo2.active = false;
		}
		if (_semaforo2 == "amarelo") {
			sinal2.GetComponent<Renderer> ().material.color = Color.yellow;
			Vermelho2.active = false;
			Amarelo2.active = true;
		}
	
	}

	IEnumerator Semaforo()
	{
		yield return new WaitForSeconds(8);
		_semaforo1 = "verde";
		yield return new WaitForSeconds(5);
		_semaforo1 = "amarelo";
		yield return new WaitForSeconds(2);
		_semaforo1 = "vermelho";
		yield return new WaitForSeconds(1);
		trocar = true;
	}
	IEnumerator Semaforo2()
	{
		yield return new WaitForSeconds(5);
		_semaforo2 = "amarelo";
		yield return new WaitForSeconds(2);
		_semaforo2 = "vermelho";
		yield return new WaitForSeconds(9);
		_semaforo2 = "verde";
		trocar = true;
	}

}

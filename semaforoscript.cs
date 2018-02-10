using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semaforoscript : MonoBehaviour {

	public GameObject Vermelho1;
	public GameObject Amarelo1;
	public GameObject Vermelho2;
	public GameObject Amarelo2;

	private float temporizador;

	private bool trocar = false;
    private enum Farois { vermelho, amarelo, verde };
    private Farois _semaforo1;
    private Farois _semaforo2;

	void Start () {
		_semaforo1 = Farois.vermelho;
		_semaforo2 = Farois.verde;
		StartCoroutine (Semaforo ());
		StartCoroutine (Semaforo2 ());
		//coliiders
		Vermelho1.active = false;
		Amarelo1.active = false;
		Vermelho2.active = false;
		Amarelo2.active = false;
	}
	
	void Update () {
		//print(temporizador + " tempo");
		temporizador = Time.time;

		if (trocar) {
			StartCoroutine (Semaforo ());
			StartCoroutine (Semaforo2 ());
			trocar = false;
		}

		if (_semaforo1 == Farois.verde) {
			Vermelho1.active = false;
			Amarelo1.active = false;
		}
		if (_semaforo1 == Farois.vermelho) {
			Vermelho1.active = true;
			Amarelo1.active = false;
		}
		if (_semaforo1 == Farois.amarelo) {
			Vermelho1.active = false;
			Amarelo1.active = true;
		}
		if (_semaforo2 == Farois.verde) {
			Vermelho2.active = false;
			Amarelo2.active = false;
		}
		if (_semaforo2 == Farois.vermelho) {
			Vermelho2.active = true;
			Amarelo2.active = false;
		}
		if (_semaforo2 == Farois.amarelo) {
			Vermelho2.active = false;
			Amarelo2.active = true;
		}
	
	}

	IEnumerator Semaforo()
	{
		yield return new WaitForSeconds(8);
		_semaforo1 = Farois.verde;
		yield return new WaitForSeconds(5);
		_semaforo1 = Farois.amarelo;
		yield return new WaitForSeconds(2);
		_semaforo1 = Farois.vermelho;
		yield return new WaitForSeconds(1);
		trocar = true;
	}
	IEnumerator Semaforo2()
	{
		yield return new WaitForSeconds(5);
		_semaforo2 = Farois.amarelo;
		yield return new WaitForSeconds(2);
		_semaforo2 = Farois.vermelho;
		yield return new WaitForSeconds(9);
		_semaforo2 = Farois.verde;
		trocar = true;
	}

}

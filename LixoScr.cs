using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoScr : MonoBehaviour {

	public GameObject carroca;
	public GameObject canvas;
	private GameObject LIXO;

	public void Palpelao(){
		carroca.GetComponent<CarrocaScript> ().carteira += 0.05f;
		carroca.GetComponent<CarrocaScript> ().pesoLixo += 0.5f;
	}
	public void Plastico(){
		carroca.GetComponent<CarrocaScript> ().carteira += 0.10f;
		carroca.GetComponent<CarrocaScript> ().pesoLixo += 0.75f;
	}
	public void Vidro(){
		carroca.GetComponent<CarrocaScript> ().carteira += 0.3f;
		carroca.GetComponent<CarrocaScript> ().pesoLixo += 1;
	}
}

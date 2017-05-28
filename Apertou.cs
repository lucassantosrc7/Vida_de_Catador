using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apertou : MonoBehaviour {

	public bool apertou = false;
	public GameObject entrega;
	public GameObject carroca;
    public GameObject tutorial;

	public void Sim(){
        tutorial.GetComponent<TutorialController>().entregar = true;
        carroca.GetComponent<CarrocaScript>().pegandolixo = false;
        carroca.GetComponent<CarrocaScript2>().pegandolixo = false;
        apertou = true;
		entrega.SetActive(false);
	}
	public void Nao(){
		apertou = false;
        carroca.GetComponent<CarrocaScript>().pegandolixo = false;
        carroca.GetComponent<CarrocaScript2>().pegandolixo = false;
        entrega.SetActive(false);
	}
}

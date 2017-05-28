using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naoesquerda : MonoBehaviour {

	private Collider2D carro;
	public GameObject esfera;
	//public GameObject vira;
	private Virar viraScr;

	private bool saiu = false;
	private int AnguloCarroF;
	private int Confere;

	private CarroScript carroScr;
	private string novaTag;
	private string[] Tags = {"virarDireita", "virarEsquerda", "virarReto"};

	void Start () {
		//viraScr = vira.GetComponent<Virar> ();
	}
	void Update () {
		/*
		if (saiu)
		{
			carroScr = carro.GetComponent<CarroScript> ();
			AnguloCarroF = carroScr.valorIni - (int)Mathf.Abs(esfera.transform.eulerAngles.z);

			Confere = AnguloCarroF - carroScr.valorIni;
			//print (Confere + " AF " + AnguloCarroF + " VI " + carroScr.valorIni);
			Confere = Mathf.Abs (Confere % 90);
			if (Confere == 0) {
				novaTag = Tags [Random.Range (0, Tags.Length)];
				carro.transform.tag = novaTag;
				carroScr.StopMeNow = false;
				carro.transform.parent = null;
			}
		}*/
	}

	public void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag ("virarDireita") || hit.CompareTag ("virarEsquerda") || hit.CompareTag ("virarReto")) {
			saiu = true;
			carro = hit;
			novaTag = Tags[1-Random.Range(-1,0)];
			carro.transform.tag = novaTag;
			carro.GetComponent<CarroScript>().StopMeNow = false;
			carro.transform.parent = null;
		}
	}
	public void OnTriggerExit2D(Collider2D hit)
	{
		if(esfera.transform.childCount == 0)
			saiu = false;
	}
}

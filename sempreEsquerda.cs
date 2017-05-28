using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sempreEsquerda : MonoBehaviour {
	private Collider2D carro;
	private string novaTag;
	private string[] Tags = {"virarDireita", "virarEsquerda", "virarReto"};


	public void OnTriggerEnter2D(Collider2D hit)
	{
		
		if (hit.CompareTag ("virarDireita") || hit.CompareTag ("virarEsquerda") || hit.CompareTag ("virarReto")) {

			carro = hit;
			novaTag = Tags[1];
			carro.transform.tag = novaTag;
		
		}
	}


}

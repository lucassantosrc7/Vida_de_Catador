using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour {

	public GameObject tutorial;

	public void Destruicao(){

		tutorial.GetComponent<TutorialController> ().coletouLixo = true;
		Destroy (gameObject);
	}

}

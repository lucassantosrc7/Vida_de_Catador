using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharABa : MonoBehaviour {

	public GameObject tutorial;

	public GameObject controlMenu;
	public GameObject carroca;

	public void fecharAba(){
		carroca.GetComponent<CarrocaScript>().pegandolixo = false;
		carroca.GetComponent<CarrocaScript2>().pegandolixo = false;
		controlMenu.SendMessage("ChangeScreen", ControlMenu.Screens.game);
	
		tutorial.GetComponent<TutorialController> ().fechouAba = true;
	
	}




}

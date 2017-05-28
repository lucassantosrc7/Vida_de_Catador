using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour {

	public GameObject LixoGrupo;

	public enum Screens{
		LixoMenu, game
	}

	private Screens actualScreen;
	private Screens lastScreen;

	void Start () {
        LixoGrupo.SetActive(false);
	}
	public void ChangeScreen(Screens newScreen){

		switch (lastScreen) {
		case Screens.LixoMenu: 
			LixoGrupo.SetActive (false);
			break;
		case Screens.game: 
			LixoGrupo.SetActive (false);
			break;
		}

		switch (newScreen) {
		case Screens.LixoMenu: 
			LixoGrupo.SetActive (true);
			break;
		case Screens.game: 
			LixoGrupo.SetActive (false);
			break;
		}
		lastScreen = newScreen;
	}
}

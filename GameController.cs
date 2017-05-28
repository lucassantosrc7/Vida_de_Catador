using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

	private float Tempo;
	private float minutos;
	private float segundos;
	public static int RoundTOint;
	private float Cronometro = 2250;

	public Text tempoText;
	
	void Start () {
		
	}
	
	
	void Update () {
		Tempo = 780 + Time.time;
		minutos = (int)(Tempo / 60f);
		segundos = (int)(Tempo % 60f);

		SetTempoText ();

		if (Tempo > Cronometro) { SceneManager.LoadScene (0); }
	}

	void SetTempoText (){
		tempoText.text = "  Horas: " + minutos.ToString ("00") + ":" +segundos.ToString ("00");
	}
}

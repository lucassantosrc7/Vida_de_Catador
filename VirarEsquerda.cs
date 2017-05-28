using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirarEsquerda : MonoBehaviour {

	public GameObject esfera;
	public int speed;
	private float tempo = 0;

	public Transform newParent;
	private int AnguloCarroI;
	private CarroScript carroScr;

	void Update () {
		if (tempo >= 0) {
			esfera.transform.Rotate (new Vector3 (0, 0, speed) * Time.deltaTime);
			tempo--;
		}
	}

	public void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag("virarEsquerda")){
			hit.transform.SetParent (newParent);
			AnguloCarroI = (int)Mathf.Abs (esfera.transform.localEulerAngles.z);
			tempo = 500;

			carroScr = hit.GetComponent<CarroScript> ();
			carroScr.StopMeNow = true;
			carroScr.valorIni = AnguloCarroI;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraVida : MonoBehaviour {

	public GameObject carroca;
	public Slider slide;

	void Update () {
		slide.value = Mathf.MoveTowards (carroca.GetComponent<CarrocaScript> ().vida , 3f, 0f);
	}
}

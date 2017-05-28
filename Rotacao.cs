
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour {

	public GameObject carroca;

	void Start () {
		
	}

	void Update () {
		
		transform.rotation = carroca.transform.localRotation;
    }
}



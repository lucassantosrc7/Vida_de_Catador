using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sumir : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hit){
        if (hit.CompareTag("Player")) {
            gameObject.SetActive(false);
        }
	}
}

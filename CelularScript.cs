using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelularScript : MonoBehaviour {
    public GameObject[] pontoscelular;
    private int mp;

	void Start () {
        for (int i = 0; i < pontoscelular.Length; i++)
        {
            pontoscelular[i].active = false;
        }
    }
	

	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            mp = Random.Range(0, pontoscelular.Length);
            for (int i = 0; i < pontoscelular.Length; i++)
            {
                pontoscelular[mp].active = true;
            }
        }

        if (Input.GetKey(KeyCode.M))
        {
            transform.position = new Vector2 (500,50 ); 
        }
	}
}

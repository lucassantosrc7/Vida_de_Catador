using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvaControler : MonoBehaviour {

    public GameObject Direita;
    public float anguloDireita; //Angulo que o carro ficará oa final da curva
    public GameObject Esquerda;
    public float anguloEsquerda; //Angulo que o carro ficará oa final da curva

    private Transform[] dir;
    private Transform[] esq;

    private enum Sorteio { direita, esquerda, reto };
    private Sorteio sorteio;
    private Sorteio[] valores;


    void Start() {
        if (Direita == null)
        {
            valores = new Sorteio[] { Sorteio.esquerda, Sorteio.reto };
            esq = Esquerda.GetComponentsInChildren<Transform>();
        }
        else if (Esquerda == null)
        {
            valores = new Sorteio[] { Sorteio.direita, Sorteio.reto };
            dir = Direita.GetComponentsInChildren<Transform>();
        }
        else {
            valores = new Sorteio[] { Sorteio.direita, Sorteio.esquerda, Sorteio.reto };
            dir = Direita.GetComponentsInChildren<Transform>();
            esq = Esquerda.GetComponentsInChildren<Transform>();
        }
    }
	
	void Update () {

    }
    void OnTriggerEnter2D(Collider2D hit) {
        ////Sorteio////
        sorteio = valores[Random.Range(0, valores.Length)];

        if (hit.CompareTag("Carro") && sorteio != Sorteio.reto) {
            hit.GetComponent<CarroScr>().estado = CarroScr.Estado.WP;
            hit.GetComponent<CarroScr>().currentWayPoint = 0;
            if (sorteio == Sorteio.direita) {
                hit.GetComponent<CarroScr>().waypoints = dir;
                hit.GetComponent<CarroScr>().angulo_Y = 90;
                hit.GetComponent<CarroScr>().anguloFinal = anguloDireita;
            } else {
                hit.GetComponent<CarroScr>().waypoints = esq;
                hit.GetComponent<CarroScr>().angulo_Y = 270;
                hit.GetComponent<CarroScr>().anguloFinal = anguloEsquerda;
            }
        }
    }
}

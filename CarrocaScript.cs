using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CarrocaScript : MonoBehaviour {

	private Animator anim;

    //Movimentação
        /*/Aceleração
            private float aceleracao = 1;
            private float desaceleracao = 1;
            private float desaceleracaoRotate = 5;
            public float velocidadeSpeed = 0;
            public float FinalSpeed = 4;
            private bool C = true;
            private bool B = true;
            private bool E = true;
            private bool D = true;
        */

    [HideInInspector]public float pesoLixo = 0;
    [HideInInspector]public float carteira = 0;

	//Estado
	public int vida = 100;

    //public GameObject lixoPrefab;

    void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*/Não deixa passar

		if (FinalSpeed <= 4)
			FinalSpeed = 4;
		if (FinalRotate <= 24)
			FinalRotate = 24;

		FinalSpeed = FinalSpeed * ((100 - pesoLixo) / 100);
		FinalRotate = FinalRotate * ((100 - pesoLixo) / 100);

		//chamaAnimaçao

		if (speed == "Parado" || rotate == "Parado") {
			anim.SetBool ("Walking", false);
		}

			if (speed == "PraFrente" && velocidadeSpeed <= FinalSpeed)
	        {
				anim.SetBool ("Walking", true);
			    tutorialmove++;
	            C = true;
	            velocidadeSpeed += aceleracao;
	        }
	        else C = false;

			if (speed == "PraTras" && velocidadeSpeed >= FinalSpeed * -1)
	        {
				anim.SetBool ("Walking", true);
			    tutorialmove++;
	            B = true;
	            velocidadeSpeed -= aceleracao;
	        }
	        else B = false;

			if (rotate == "PraEsquerda" && velocidadeRotate <= FinalRotate)
	        {
				anim.SetBool ("Walking", true);
			    tutorialmove++;
	            E = true;
	           velocidadeRotate += aceleracao;
	        }
	        else E = false;

			if (rotate == "PraDireita" && velocidadeRotate >= FinalRotate* -1)
	        {
				anim.SetBool ("Walking", true);
			    tutorialmove++;
	            D = true;
	            velocidadeRotate -= aceleracao;
	        }
	        else D = false;

			if (!C && !B && velocidadeSpeed > 0) velocidadeSpeed -= desaceleracao;
			else if (!C && !B && velocidadeSpeed < 0) velocidadeSpeed += desaceleracao;
			if (!E && !D && velocidadeRotate > 0) velocidadeRotate -= desaceleracaoRotate;
			else if (!E && !D && velocidadeRotate < 0) velocidadeRotate += desaceleracaoRotate;

			if (rotate == "PraEsquerda" && rodaquebrada == 0 && !pegandolixo) {
				transform.Rotate(new Vector3(0, 0, FinalRotate) * Time.deltaTime);
			}
		
			if (rotate == "PraDireita" && rodaquebrada == 0 && !pegandolixo) {
				transform.Rotate(new Vector3(0, 0, -FinalRotate) * Time.deltaTime);
			}

		if (rodaquebrada > 0) Rodaquebrada ();
	 */		
    }

	void OnCollisionEnter2D(Collision2D hit){
		if(hit.collider.CompareTag("virarDireita") || hit.collider.CompareTag ("virarEsquerda") || hit.collider.CompareTag ("virarReto")){
			vida -= 25;
		}
	}

}


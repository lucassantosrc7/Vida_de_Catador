using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CarrocaScript : MonoBehaviour {

	public GameObject controlMenu;


	//tutorial
	public bool EstaNoTutorial = true;
	public int tutorialmove = 0;
	public bool tutorialLixeira = false;
	//Movimentação
		//Aceleração
	    private float aceleracao = 1;
	    private float desaceleracao = 1;
		private float desaceleracaoRotate = 5;
	    private float velocidadeSpeed = 0;
	    public float FinalSpeed = 4;

	    private float velocidadeRotate = 0;
	    private float FinalRotate = 72;
		public string speed = "Parado";
		public string rotate = "Parado";

		public int rodaquebrada = 0;
		public bool pegandolixo = false;

	    private bool C = true;
	    private bool B = true;
	    private bool E = true;
	    private bool D = true;

	//Lixo
	public GameObject slot1;
	public GameObject slot2;
	public GameObject slot3;

    public float pesoLixo = 0;
	public float carteira = 0;

	//Estado
	public int vida = 3;

    //public GameObject lixoPrefab;

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (rodaquebrada >= 3) {
			velocidadeRotate = 0;
			velocidadeSpeed = 0;
		}
		//Não deixa passar

		if(FinalSpeed <= 4) FinalSpeed = 4;
		if (FinalRotate <= 24) FinalRotate = 24;

		FinalSpeed = FinalSpeed * ((100 - pesoLixo) / 100);
		FinalRotate = FinalRotate * ((100 - pesoLixo) / 100);

		if(!pegandolixo){transform.Translate(new Vector2(0, velocidadeSpeed) * Time.deltaTime);}
		if(!pegandolixo){transform.Rotate(new Vector3(0, 0, velocidadeRotate) * Time.deltaTime);}

			if (speed == "PraFrente" && velocidadeSpeed <= FinalSpeed)
	        {
			    tutorialmove++;
	            C = true;
	            velocidadeSpeed += aceleracao;
	        }
	        else C = false;

			if (speed == "PraTras" && velocidadeSpeed >= FinalSpeed * -1)
	        {
			    tutorialmove++;
	            B = true;
	            velocidadeSpeed -= aceleracao;
	        }
	        else B = false;

			if (rotate == "PraEsquerda" && velocidadeRotate <= FinalRotate)
	        {
			    tutorialmove++;
	            E = true;
	           velocidadeRotate += aceleracao;
	        }
	        else E = false;

			if (rotate == "PraDireita" && velocidadeRotate >= FinalRotate* -1)
	        {
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
			
    }
	void OnTriggerEnter2D(Collider2D hit)
	{
		
        if(hit.CompareTag("Lixo"))
        {
			if (EstaNoTutorial) {
				tutorialLixeira = true;
				pegandolixo = true;
				slot1.GetComponent<IniLixos> ().SortearLixo (3);
				slot2.GetComponent<IniLixos> ().SortearLixo (1);
				slot3.GetComponent<IniLixos> ().SortearLixo (3);
				controlMenu.SendMessage ("ChangeScreen", ControlMenu.Screens.LixoMenu);
				EstaNoTutorial = false;
				hit.transform.tag = "LixoUsado";
			} else {
				pegandolixo = true;
				slot1.GetComponent<IniLixos> ().SortearLixo (Random.Range(0,4));
				slot2.GetComponent<IniLixos> ().SortearLixo (Random.Range(0,4));
				slot3.GetComponent<IniLixos> ().SortearLixo (Random.Range(0,4));
				controlMenu.SendMessage("ChangeScreen", ControlMenu.Screens.LixoMenu);
				hit.transform.tag = "LixoUsado";
			}
		
           /*Destroy(hit);
            hit.GetComponent<SpriteRenderer>().enabled = false;
            Clixo();*/
        }
		else if(hit.CompareTag("LixoUsado"))
		{
			pegandolixo = true;
			controlMenu.SendMessage("ChangeScreen", ControlMenu.Screens.LixoMenu);
		}
	}

  

    void Rodaquebrada () {
	
		if (Input.GetKey(KeyCode.LeftArrow) && velocidadeRotate <= FinalRotate)
		{
			E = true;
			velocidadeRotate += aceleracao;
		}
		else E = false;

		if (Input.GetKey(KeyCode.RightArrow) && velocidadeRotate >= FinalRotate* -1)
		{
			D = true;
			velocidadeRotate -= aceleracao;
		}
		else D = false;

		if (!E && !D && velocidadeRotate > 0) velocidadeRotate -= desaceleracao*(1/rodaquebrada);
		else if (!E && !D && velocidadeRotate < 0) velocidadeRotate += desaceleracao*(1/rodaquebrada);

	
	}

}


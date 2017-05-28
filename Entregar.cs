using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Entregar : MonoBehaviour {

    private bool dao = false;
	public GameObject entrega;
	public GameObject lixao;
    public GameObject tutorial;

	public Text valorText;

	public GameObject carroca;
	private CarrocaScript CScr;
	private float valorLixo;

	void Start () {
		CScr = carroca.GetComponent<CarrocaScript> ();
		valorLixo = 0.00f;
		entrega.SetActive(false);
	}
	

	void Update () {
		valorLixo = CScr.carteira;
		if(dao && Input.GetKey(KeyCode.E)){
			SetLixoText ();
		}
//		print(dao);
		if (dao && lixao.GetComponent<Apertou>().apertou)
        {
			SetLixoText ();
			lixao.GetComponent<Apertou>().apertou = false;
		}
	}
	void SetLixoText (){
		valorText.text = "Carteira: " + "R$ " + valorLixo.ToString ("00.00") + "  ";
	}

	void OnTriggerEnter2D(Collider2D hit){
        if (hit.CompareTag("Player")) {
            dao = true;
            carroca.GetComponent<CarrocaScript>().pegandolixo = true;
            carroca.GetComponent<CarrocaScript2>().pegandolixo = true;
            entrega.SetActive(true);
            tutorial.GetComponent<TutorialController>().entrouLixao = true;
        }
	}
    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            dao = false;
            carroca.GetComponent<CarrocaScript>().pegandolixo = false;
            carroca.GetComponent<CarrocaScript2>().pegandolixo = false;
            tutorial.GetComponent<TutorialController>().seta_Lixao.SetActive(true);
        }
    }
}

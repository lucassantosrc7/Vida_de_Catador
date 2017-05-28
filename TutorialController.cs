using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialController : MonoBehaviour {

	private bool comecoTutorial;
	private bool comecoLixeira = false;
	public bool coletouLixo = false;
	public bool  fechouAba = false;
    public bool entrouLixao = false;
    public bool entregar = false;


    private bool fala2bool = false;
    private bool fala6bool = false;
    private bool fala7bool = false;
    private bool fala8bool = false;
    private float num = -0.1f;
    private int cont = 5;
    private Vector2 repOriginal;
    private Vector2 vidaOriginal;
    // imagens

    public Image fala1;
	public Image fala2;
	public Image fala3;
	public Image fala4;
	public Image fala5;
	public Image fala6;
	public Image fala7;
	public Image fala8;
	public Image fala9;
	public Image fala10;
	public Image fala11;
	public Image fala12;
    public Slider Rep;
    public Slider Vida;

    [Space(10)]

	public GameObject seta_lixeira;
	public Image seta_Lixo;
	public Image seta_Aba;
	public GameObject seta_Lixao;
	public GameObject seta_Lixao2;
    public Image seta_Entregar;
    public Image seta_Dinheiro;

    public GameObject setas_Tutorial;

    // obj

    public GameObject carroca;

	void Start () {
		fala1.gameObject.SetActive(false);
		fala2.gameObject.SetActive(false);
		fala3.gameObject.SetActive(false);
		fala4.gameObject.SetActive(false);
		fala5.gameObject.SetActive(false);
		fala6.gameObject.SetActive(false);
		fala7.gameObject.SetActive(false);
		fala8.gameObject.SetActive(false);
		fala9.gameObject.SetActive(false);
		fala10.gameObject.SetActive(false);
		fala11.gameObject.SetActive(false);
		fala12.gameObject.SetActive(false);

		seta_lixeira.SetActive (false);
		seta_Lixo.gameObject.SetActive(false);
		seta_Aba.gameObject.SetActive(false);
        seta_Lixao.SetActive(false);
        seta_Lixao2.SetActive(false);
        seta_Entregar.gameObject.SetActive(false);
        seta_Dinheiro.gameObject.SetActive(false);

        repOriginal = new Vector2 (Rep.gameObject.transform.localScale.x, Rep.gameObject.transform.localScale.y);
        vidaOriginal = new Vector2(Vida.gameObject.transform.localScale.x, Vida.gameObject.transform.localScale.y);
    }
	
	// Update is called once per frame
	void Update () {

        /*if (Input.GetMouseButtonDown(0) && !comecoTutorial)
        {
            fala1.gameObject.SetActive(true);
            comecoTutorial = true;
        }*/
        if (Input.GetMouseButtonDown(0) && fala1.IsActive())
        {
            fala1.gameObject.SetActive(false);
            fala2.gameObject.SetActive(true);
        }
        else if (Input.GetMouseButtonDown(0) && fala2.IsActive())
        {
            fala2.gameObject.SetActive(false);
            fala2bool = true;
        }
        else if (fala2bool)
        {
            if (carroca.GetComponent<CarrocaScript>().tutorialmove >= 300 || carroca.GetComponent<CarrocaScript2>().tutorialmove2 >= 300) {
                fala3.gameObject.SetActive(true);
                fala2bool = false;
                carroca.GetComponent<CarrocaScript>().tutorialmove = 0;
                carroca.GetComponent<CarrocaScript2>().tutorialmove2 = 0;
            }
        }
        else if (Input.GetMouseButtonDown(0) && fala3.IsActive())
        {
            fala3.gameObject.SetActive(false);
            seta_lixeira.SetActive(true);
        }
        else if (carroca.GetComponent<CarrocaScript>().tutorialLixeira)
        {
            seta_lixeira.SetActive(false);
            seta_Lixo.gameObject.SetActive(true);
            carroca.GetComponent<CarrocaScript>().tutorialLixeira = false;
        }
        else if (coletouLixo)
        {
            seta_Lixo.gameObject.SetActive(false);
            seta_Aba.gameObject.SetActive(true);
            coletouLixo = false;
        }
        else if (seta_Aba.IsActive() && fechouAba)
        {
            seta_Aba.gameObject.SetActive(false);
            fala4.gameObject.SetActive(true);
            fechouAba = false;
        }
        else if (Input.GetMouseButtonDown(0) && fala4.IsActive())
        {
            fala4.gameObject.SetActive(false);
            seta_Lixao.SetActive(true);
            seta_Lixao2.SetActive(true);
        }
        else if (entrouLixao)
        {
            seta_Lixao.SetActive(false);
            seta_Entregar.gameObject.SetActive(true);
            entrouLixao = false;
        }
        else if (entregar)
        {
            entregar = false;
            seta_Entregar.gameObject.SetActive(false);
            fala5.gameObject.SetActive(true);
            seta_Dinheiro.gameObject.SetActive(true);
        }
        else if (Input.GetMouseButtonDown(0) && fala5.IsActive())
        {
            fala5.gameObject.SetActive(false);
            seta_Dinheiro.gameObject.SetActive(false);
            fala6bool = true;
            fala6.gameObject.SetActive(true);
        }
        else if (Input.GetMouseButtonDown(0) && fala6.IsActive())
        {
            fala6.gameObject.SetActive(false);
            fala7.gameObject.SetActive(true);
            fala6bool = false;
            fala7bool = true;
            Rep.gameObject.transform.localScale = new Vector3(repOriginal.x, repOriginal.y, Rep.gameObject.transform.localScale.z);
        }
        else if (fala6bool) {
            if (cont >= 30) {
                num *= -1;
                Rep.gameObject.transform.localScale = new Vector3(Rep.gameObject.transform.localScale.x + num, Rep.gameObject.transform.localScale.y + num, Rep.gameObject.transform.localScale.z);
                cont = 0;
            }
            else { cont++; }
        }
        else if (Input.GetMouseButtonDown(0) && fala7.IsActive())
        {
            fala7.gameObject.SetActive(false);
            fala9.gameObject.SetActive(true);
            fala7bool = false;
            Vida.gameObject.transform.localScale = new Vector3(vidaOriginal.x, vidaOriginal.y, Vida.gameObject.transform.localScale.z);
        }
        else if (fala7bool)
        {
            if (cont >= 30)
            {
                num *= -1;
                Vida.gameObject.transform.localScale = new Vector3(Vida.gameObject.transform.localScale.x + num, Vida.gameObject.transform.localScale.y + num, Vida.gameObject.transform.localScale.z);
                cont = 0;
            }
            else { cont++; }
        }
        else if (Input.GetMouseButtonDown(0) && fala9.IsActive())
        {
            fala9.gameObject.SetActive(false);
            fala10.gameObject.SetActive(true);
        }
        else if (Input.GetMouseButtonDown(0) && fala10.IsActive())
        {
            fala10.gameObject.SetActive(false);
            fala11.gameObject.SetActive(true);
        }
        else if (Input.GetMouseButtonDown(0) && fala11.IsActive())
        {
            fala11.gameObject.SetActive(false);
            fala12.gameObject.SetActive(true);
        }
        else if (Input.GetMouseButtonDown(0) && fala12.IsActive())
        {
            gameObject.SetActive(false);
            setas_Tutorial.SetActive(false);
        }

    }
}

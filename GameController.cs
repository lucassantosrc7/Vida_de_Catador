using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float Tempo;
	private float tempoIni = 780;
	public float minutos;
	public float segundos;
	public static int RoundTOint;
	private float Cronometro = 1080;

	//reseta fase
	public GameObject Carroca;
    private CarrocaScript carrocaScr;
	private Vector2 posCarroca;

	public Text tempoText;

    //Lixos Adjetivos
    [Space(20)]
    [SerializeField] public GameObject lixo;//Game Empty onde estará os outros objetos
    [SerializeField] public Button[] obj_Lixos;
    [SerializeField] public RectTransform[] pos_Lixos;
        //fecharLixo
        public static List<Button> lixos;

    void Start () {
        carrocaScr = Carroca.GetComponent<CarrocaScript>();
		posCarroca = Carroca.transform.position;

        lixo.SetActive(false);
	}
	
	
	void Update () {
		Tempo = tempoIni + Time.time;
		minutos = (int)(Tempo / 60f);
		segundos = (int)(Tempo % 60f);

        //SetTempoText ();

        /*////Reseta Vida
		if(carrocaScr.vida <= 0 || Tempo > Cronometro){
			Carroca.transform.position = posCarroca;
			carrocaScr.vida = 10;
			carrocaScr.carteira = 0;
			tempoIni = 780;
		}*/

    }

    /*void SetTempoText (){
		tempoText.text =  minutos.ToString ("00") + ":" +segundos.ToString ("00");
	}*/

    public void FecharComponents(List<Button> lixos_List) {
        if (lixos_List.Count == 0)
        {
            lixo.SetActive(false);
            Movimentação.estado = Movimentação.Estado.mover;
        } else
        {
            for (int i = 0; i < lixos_List.Count; i++)
            {
                lixos_List[i].gameObject.SetActive(false);
                if (i == lixos_List.Count - 1)
                {
                    lixo.SetActive(false);
                    Movimentação.estado = Movimentação.Estado.mover;
                }
            }
        }
    }

    public void FecharAba()
    {
        FecharComponents(lixos);
    }
}

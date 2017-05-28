using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroScript : MonoBehaviour {

	public bool StopMeNow ;
	public int valorIni;
	private float anguloCar;
	public GameObject referenciaD;
    public GameObject referenciaE;
    public GameObject referenciaM;
    //Variaveis do Ray
    private float RayXD;
	private float RayYD;
    private float RayXE;
    private float RayYE;
    private float RayXM;
    private float RayYM;

    private float aceleracao = 1;
	private float desaceleracao = 1;
	private float velocidadeSpeed = 0;
	private float VelocidadeMax = 6;

	private string novaTag;
	private string[] Tags = {"virarDireita", "virarEsquerda", "virarReto"};

	void Start(){
		novaTag = Tags [Random.Range (0, Tags.Length)];
		transform.tag = novaTag;
		StopMeNow = false;
	}

	void Update () {

		transform.Translate (new Vector2 (0, velocidadeSpeed) * Time.deltaTime);

		if (!StopMeNow && !transform.parent) {

			if (transform.localEulerAngles.z % 90 != 0 && transform.localEulerAngles.z > 90) {
				anguloCar = transform.localEulerAngles.z % 90;
				transform.Rotate (new Vector3 (0, 0, -anguloCar));
			} else if (transform.localEulerAngles.z % 90 != 0 && transform.localEulerAngles.z < 90) {
				anguloCar = transform.localEulerAngles.z % 90;
				transform.Rotate (new Vector3 (0, 0, -anguloCar));
			}
			if (velocidadeSpeed <= VelocidadeMax) {
				velocidadeSpeed += aceleracao;
			}
		} else if (velocidadeSpeed >= 1 && (transform.parent || StopMeNow)) {
			velocidadeSpeed -= desaceleracao;
		}
			
		RayXD = referenciaD.transform.position.x - transform.position.x;
		RayYD = referenciaD.transform.position.y - transform.position.y;

		RayXE = referenciaE.transform.position.x - transform.position.x;
        RayYE = referenciaE.transform.position.y - transform.position.y;

        RayXM = referenciaM.transform.position.x - transform.position.x;
        RayYM = referenciaM.transform.position.y - transform.position.y;

        RaycastHit2D hit = Physics2D.Raycast(referenciaD.transform.position, new Vector2(RayXD,RayYD), 3f);
		RaycastHit2D hit2 = Physics2D.Raycast(referenciaE.transform.position, new Vector2(RayXE, RayYE), 3f);
		RaycastHit2D hit3 = Physics2D.Raycast(referenciaM.transform.position, new Vector2(RayXM, RayYM), 3f);

		if (hit.collider && !hit.collider.CompareTag ("Entrar") && !hit.collider.CompareTag ("Saida")) {
			if (!hit.collider.isTrigger) {
				StopMeNow = true;
			}
		}
        else if (hit2.collider && !hit2.collider.CompareTag("Entrar") && !hit2.collider.CompareTag("Saida"))
        {
            if (!hit2.collider.isTrigger)
            {
                StopMeNow = true;
            }
        }
        else if (hit3.collider && !hit3.collider.CompareTag("Entrar") && !hit3.collider.CompareTag("Saida"))
        {
            if (!hit3.collider.isTrigger)
            {
                StopMeNow = true;
            }
        }
		else if (!transform.parent) { StopMeNow = false; }

        Debug.DrawRay(referenciaE.transform.position, new Vector2(RayXE, RayYE), Color.red);
        Debug.DrawRay(referenciaD.transform.position, new Vector2(RayXD, RayYD), Color.red);
        Debug.DrawRay(referenciaM.transform.position, new Vector2(RayXM, RayYM), Color.red);
	}		
}

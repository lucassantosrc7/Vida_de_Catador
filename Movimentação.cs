
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimentação : MonoBehaviour {

    public enum Estado {
        mover,
        parado,
    }
    public static Estado estado = Estado.mover;

    #region carroca var
    public int vida;
    public static float carteira;
    public static float peso;
    #endregion

    #region movimentação var
    public float moveSpeed = 2.0f;
    public float rotacao = 0.01f;
    public float trava = 7;
    private Vector2 pos;
    #endregion

    #region entrega var
    [Space(20)]
    [SerializeField]private GameObject confimar_Botoes;//botoes se quer ou não entregar o lixo
    [SerializeField]private Text carteira_txt;
    #endregion

    void Start () {
        pos = transform.position.normalized;
	}

	void Update () {

        if (Input.GetMouseButton(0) && estado == Estado.mover) {
			var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //rotaciona pra direção do mouse
                // convert mouse position into world coordinates
                Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
                // get direction you want to point at
                Vector2 direction = (mouseWorldPosition - (Vector2) transform.position).normalized;

                // set vector of transform directly
                pos = transform.up;
                if (direction.x >= pos.x)
                {
                    pos.x += rotacao;
                }
                else pos.x -= rotacao;

                if (direction.y > pos.y)
                {
                    pos.y += rotacao;
                }
                else pos.y -= rotacao;

                transform.up = pos;

            //movimentação pra direção do mouse
            targetPos.z = transform.position.z;
            Vector2 Apontar = -transform.up;

            if ((Mathf.Abs(direction.x - pos.x) < trava) && (Mathf.Abs(direction.y - pos.y) < trava))
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            }
            else if (direction.x >= Apontar.x - 0.5 && direction.x <= Apontar.x + 0.5 && direction.y >= Apontar.y - 0.5 && direction.y <= Apontar.y + 0.5)
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Lixao"))
        {
            confimar_Botoes.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.CompareTag("Lixao"))
        {
            confimar_Botoes.SetActive(false);
        }
    }

    #region entregar Lixo
    public void Sim() {
        carteira_txt.text = carteira.ToString("0.00");
        confimar_Botoes.SetActive(false);
    }
    public void Nao() {
        confimar_Botoes.SetActive(false);
    }
    #endregion

}



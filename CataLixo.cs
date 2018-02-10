using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CataLixo : MonoBehaviour {

    //Lixo
    public GameController gameController;
    [HideInInspector] public List <Button> lixos;

    void Awake () {

        lixos = new List<Button>();

        for (int i = 0; i < gameController.pos_Lixos.Length; i++) {
            if (Random.Range(0, 2) == 0) {
                int lixo = Random.Range(0, gameController.obj_Lixos.Length);
                lixos.Add(Instantiate(gameController.obj_Lixos[lixo]));
                lixos[lixos.Count - 1].GetComponent<Botoes>().lixo = gameObject;
                lixos[lixos.Count - 1].transform.SetParent(gameController.lixo.transform);
                lixos[lixos.Count - 1].transform.position = gameController.pos_Lixos[i].position;
                lixos[lixos.Count - 1].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        /*if (GameController.clicou) {
            print(lixos.Count);
            for (int i = 0; i < lixos.Count; i++)
            {
                lixos[i].gameObject.SetActive(false);
                if (i == lixos.Count - 1)
                {
                    gameController.lixos.SetActive(false);
                    GameController.clicou = false;
                    Movimentação.estado = Movimentação.Estado.mover;
                }
            }
        }*/
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player")) {
            Movimentação.estado = Movimentação.Estado.parado;
            GameController.lixos = lixos;
            gameController.lixo.SetActive(true);
            for (int i = 0; i < lixos.Count; i++)
            {
                lixos[i].gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            gameController.FecharComponents(lixos);
        }
    }
}

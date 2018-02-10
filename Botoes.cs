using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botoes : MonoBehaviour {

    [SerializeField] private float valor;
    [SerializeField] private float peso;

    [HideInInspector] public GameObject lixo;

    public void pegarLixo() {
        Movimentação.peso += peso;
        Movimentação.carteira += valor;
        lixo.GetComponent<CataLixo>().lixos.Remove(gameObject.GetComponent<Button>());
        Destroy(gameObject);
    }

    public void FecharAba(GameObject obj_pFechar) {
        obj_pFechar.SetActive(false);
    }
}

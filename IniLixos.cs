using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IniLixos : MonoBehaviour {

	public Transform Slotransform;
	public Button Slot;

	public Button Papel_Prefab;
	public Button Plastico_Prefab;
	public Button vidro_Prefab;

	private int num;
	private bool roberto;

	void Start () {
		
	}

	void Update () {
		
	}
	public void SortearLixo(int n){
		num = n;
		if (num == 0) {
			Button Lixo;
			Lixo = Instantiate (Papel_Prefab);
			Lixo.transform.SetParent (Slotransform);
			Lixo.transform.position = new Vector2 (Slot.transform.position.x, Slot.transform.position.y);
		} else if (num == 1) {
			Button Lixo;
			Lixo = Instantiate (Plastico_Prefab);
			Lixo.transform.SetParent (Slotransform);
			Lixo.transform.position = new Vector2 (Slot.transform.position.x, Slot.transform.position.y);
		} else if (num == 2) {
			Button Lixo;
			Lixo = Instantiate (vidro_Prefab);
			Lixo.transform.SetParent (Slotransform);
			Lixo.transform.position = new Vector2 (Slot.transform.position.x, Slot.transform.position.y);
		}
		num = 10;
	}
}

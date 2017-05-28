using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMenuLixo : MonoBehaviour {

	public void destruirTudo(){

		if(transform.Find("PlasticoButton(Clone)")){
			GameObject Plastico = transform.Find("PlasticoButton(Clone)").gameObject;
			Destroy(Plastico);
		}else if(transform.Find("PapelButton(Clone)")){
			GameObject Papel = transform.Find("PapelButton(Clone)").gameObject;
			Destroy(Papel);
		}else if(transform.Find("VidroButton(Clone)")){
			GameObject Vidro = transform.Find("VidroButton(Clone)").gameObject;
			Destroy(Vidro);
		}
	}

}

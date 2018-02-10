using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroSom : MonoBehaviour {

    public GameObject carroca;
    private Vector2 distancia;

    private AudioSource source;
    public AudioClip carro;
    private float volume;
	public bool estaTocando;

	void Start () {
		
        source = GetComponent<AudioSource>();
        source.PlayOneShot(carro, 1);
		estaTocando = true;
    }


    void Update()
    {
		if(estaTocando)
		{
        distancia = new Vector2(Mathf.Abs(carroca.transform.position.x - transform.position.x),
                                 Mathf.Abs(carroca.transform.position.y - transform.position.y));
        if (!source.isPlaying) { source.PlayOneShot(carro, 1); }
            
        source.volume = volume;

        if (distancia.x < 10 && distancia.y < 10)
         {
             distancia.x *= 1;
             volume = distancia.x * 0.1f;
             volume = 1 - volume;
         }
         else { source.volume = 0; }
    }
	}
}

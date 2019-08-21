using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarKunai : MonoBehaviour{
	
    AudioSource sonido;
    public AudioClip espada_choque;
    // Start is called before the first frame update
    void Start()
    {        
        sonido = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    	        
    }
    void OnCollisionStay2D(Collision2D col)
    {
                
        if (col.gameObject.tag == "arma_enemiga")
        {           
            sonido.clip = espada_choque;  
            sonido.Play();             
            //Destroy(gameObject);
            //Destroy(col.gameObject);            
        }
    }
}

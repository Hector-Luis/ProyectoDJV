using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScene : MonoBehaviour
{
	public float tiempo = 0.0f;
	public float fin = 2.0f;

    // Start is called before the first frame update
    void Start()
    {    	
        
    }

    // Update is called once per frame
    void Update()
    {
    	tiempo = tiempo + Time.deltaTime;
    	if(tiempo > fin){
    		//Debug.Log("entro");
    		Application.LoadLevel ("Credits");
    	}
        
    }
}

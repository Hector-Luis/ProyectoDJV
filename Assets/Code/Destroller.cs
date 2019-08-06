using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Debug.Break();
            //funcion game over
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
            GameObject personaje = GameObject.Find("Player");
            // Destroy(personaje);
            personaje.SetActive(false);
        }
        else {
            Destroy(collision.gameObject); //destruye los objetos colisionados 
        }

        }
}

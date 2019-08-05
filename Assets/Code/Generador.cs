using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{

    public GameObject[] obj;
    public float tiempoMin = 1.5f; //segundo en que tarda de aparecer otro bloque
    public float tiempoMax = 4f; //segundo en que varia el aparecer otro bloque
    // Start is called before the first frame update
    void Start()
    {
        // Generar(); 
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");//esta es la notificacion
    }

    void PersonajeEmpiezaACorrer(Notification notification)
    {
        Generar();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void Generar()
    {
        Instantiate(obj[Random.Range(0, obj.Length)],transform.position,Quaternion.identity); //el length del obj no se incluye en el ramdon
        Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
    }
}

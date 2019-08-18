using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{

    public GameObject[] obj;
    public float tiempoMin = 2f; //segundo en que tarda de aparecer otro bloque
    public float tiempoMax = 5f; //segundo en que varia el aparecer otro bloque
    // Start is called before the first frame update
    void Start()
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

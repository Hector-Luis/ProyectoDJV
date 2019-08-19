using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{

    public int puntos = 0;
    public TextMesh marcador;
    // Start is called before the first frame update
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");

        ActualizarMarcador();
    }



    void PersonajeHaMuerto(Notification notification)
    {
        if(puntos > Estadogame.estadogame.puntuacionMaxima)
        {
          //  Debug.Log("Puntucion maxima alcanzada su puntuacion fue: " + Estadogame.estadogame.puntuacionMaxima + " Actual " + puntos);
            Estadogame.estadogame.puntuacionMaxima = puntos;
            Estadogame.estadogame.Guardar();
        }
        /*else
        {
            Debug.Log("Record No superado: " + Estadogame.estadogame.puntuacionMaxima + " Actual " + puntos);
        }*/
    }
    void IncrementarPuntos(Notification notification)
    {
        int puntosAIncrementar = (int)notification.data;
        puntos += puntosAIncrementar;
        ActualizarMarcador();
       Debug.Log("Incrementado" + puntosAIncrementar + "Puntos. Total Ganados: " + puntos);
    }
    // Update is called once per frame

        void ActualizarMarcador()
    {
        marcador.text = puntos.ToString();
    }
    void Update()
    {
        
    }
}

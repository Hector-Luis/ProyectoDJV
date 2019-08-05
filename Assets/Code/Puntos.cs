﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{

    public int puntos = 0;
    // Start is called before the first frame update
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
    }

    void IncrementarPuntos(Notification notification)
    {
        int puntosAIncrementar = (int)notification.data;
        puntos += puntosAIncrementar;
        Debug.Log("Incrementado" + puntosAIncrementar + "Puntos. Total Ganados: " + puntos);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualizarValoresGameOver : MonoBehaviour
{

    public TextMesh total;
    public TextMesh record;
    public Puntos puntos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        // Debug.Log("Activado !!");
        total.text = puntos.puntos.ToString();
      record.text=  Estadogame.estadogame.puntuacionMaxima.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    // Start is called before the first frame update
    public bool InicarEnMovimiento = false;
    public float velocidad = 0f;
    private bool enMovimiento = false;
    private float tiempoInicio = 0f;
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");

        if (InicarEnMovimiento)
        {
            // enMovimiento = true;
            PersonajeEmpiezaACorrer();
        }
    }

    void PersonajeHaMuerto()
    {
        enMovimiento = false;
    }

    void PersonajeEmpiezaACorrer()
    {
        enMovimiento = true;
        tiempoInicio = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //  Renderer.material.mainTextureOffset = new Vector2(Time.time + velocidad,0);
        if (enMovimiento)
        {
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
        }


    }
}

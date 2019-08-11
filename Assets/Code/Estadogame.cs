using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;//serializa en binario
using System.IO;
public class Estadogame : MonoBehaviour
{
    public int puntuacionMaxima = 0;
    public static Estadogame estadogame;

    private String rutaArchivo;
    void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/datos.dat";
        //Debug.Log(Application.persistentDataPath);
        if (estadogame == null)
        {
            estadogame = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(estadogame!=this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cargar(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Guardar()
    {
        BinaryFormatter nf = new BinaryFormatter();
        FileStream file = File.Create(rutaArchivo);

        DatosAGuardar datos = new DatosAGuardar();
        datos.puntuacionMaxima = puntuacionMaxima;

        nf.Serialize(file, datos);
        file.Close();
    }

    void Cargar()
    {
        if (File.Exists(rutaArchivo))
        {
            BinaryFormatter nf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);
            DatosAGuardar datos = (DatosAGuardar)nf.Deserialize(file);

            puntuacionMaxima = datos.puntuacionMaxima;

            file.Close();
        }
        else
        {
            puntuacionMaxima = 0;
        }
    }

    [Serializable]
    class DatosAGuardar
    {
        public int puntuacionMaxima;

        public DatosAGuardar()
        {
        }

        public DatosAGuardar(int puntuacionMaxima)
        {
            this.puntuacionMaxima = puntuacionMaxima;
        }
    }
}

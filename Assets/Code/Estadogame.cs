using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estadogame : MonoBehaviour
{
    public int puntuacionMaxima = 0;
    public static Estadogame estadogame;
    void Awake()
    {
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

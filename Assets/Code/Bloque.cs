using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{

    private bool colsionjugador = false;
    public int puntosIncrementar = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!colsionjugador && collision.gameObject.tag == "Player")
        {
            colsionjugador = true;
            //Debug.Log("collision detectada");
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos",puntosIncrementar);

        }
    }
}

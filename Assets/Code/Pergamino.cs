using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pergamino : MonoBehaviour
{
    // Start is called before the first frame update
    public int pergaminoValue = 1;// aumenta este entero en 1 es el parametro que se le pasa a la clase scorepergamino


    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if (collision.gameObject.CompareTag("PLayer"))


        //la estupida y sensual colision
       if(collision.tag == "Player")
        {
            Scorepergaminos.instance.ChangeScore(pergaminoValue);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

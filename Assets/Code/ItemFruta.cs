using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFruta : MonoBehaviour
{
    public int puntosIncrementar = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosIncrementar);
            //Debug.Log("tocado");
          
        }
        Destroy(gameObject);//destruir el objeto
    }
}

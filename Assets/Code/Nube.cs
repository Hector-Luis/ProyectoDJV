using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private EdgeCollider2D ec2d;
    private Vector3 inicio;

    public float t_caida = 2f;
    public float t_regreso = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ec2d = GetComponent<EdgeCollider2D>();
        inicio = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            Invoke("Caer", t_caida);
            Invoke("Regresar", t_caida + t_regreso);
        }
    }

    void Caer(){        
        rb2d.isKinematic = false;
        ec2d.isTrigger = true;
    }

    void Regresar()
    {
        this.transform.position = inicio;
        rb2d.isKinematic = true;
        ec2d.isTrigger = false;
        rb2d.velocity = Vector3.zero;
    }
}

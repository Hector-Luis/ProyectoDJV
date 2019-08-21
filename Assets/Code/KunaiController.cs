using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public float speed = 1f;
    public float max_speed = 3f;
    private Vector3 inicio;
    private Rigidbody2D rb2d;
    public AudioClip choque_armas;
    AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        inicio = this.transform.position;
        sonido = gameObject.GetComponent<AudioSource>();
        //sonido.clip = choque_armas;       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.left * speed * -1f);
        float limit_speed = Random.Range(speed,max_speed);
        //Debug.Log("vel kunai: " + limit_speed);
        rb2d.velocity = new Vector2(limit_speed * -1f, rb2d.velocity.y);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log("Colision con : " + col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }       
        if (col.gameObject.tag == "kunai_player")
        {
            Debug.Log("CHOQUE DE KUNAIS");  
            sonido.clip = choque_armas;  
            sonido.Play();   
            Destroy(col.gameObject);            
            gameObject.GetComponent<Renderer>().enabled = false;
                    
        }
       /* if (col.gameObject != null)
        {
            Destroy(gameObject);
        }*/
    }    

    void OnBecameInvisible()
    {
        Destroy(gameObject);        
    }

    /*public void reset() {
        this.transform.position = inicio;
    }*/
}

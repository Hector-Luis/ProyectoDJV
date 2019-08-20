using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiPlayer : MonoBehaviour
{
    public float speed = 1f;
    public float max_speed = 3f;
    private Vector3 inicio;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        inicio = this.transform.position;
        rb2d.AddForce(Vector2.left * speed);
        float limit_speed = Random.Range(speed, max_speed);        
        rb2d.velocity = new Vector2(limit_speed, rb2d.velocity.y);
    }

   
    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log("Colision con : " + col.gameObject.tag);
        if (col.gameObject.tag == "arma_enemiga")
        {
            Debug.Log("CHOQUE DE KUNAIS player");
            Destroy(gameObject);
           // Destroy(col.gameObject);
        }
    }

   
}

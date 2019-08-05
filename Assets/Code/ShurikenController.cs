using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    public float speed = 1f;
    public float max_speed = 3f;
    private Vector3 inicio;
    private Rigidbody2D rb2d;
    private float rotacion = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        inicio = this.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (rotacion < 360.0f)
        {
            rotacion += 20.0f;
        }
        else {
            rotacion = 1.0f;
        }
        this.transform.Rotate(new Vector3(0.0f,0.0f,rotacion));
    }

    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.left * speed * -1f);
        float limit_speed = Random.Range(speed, max_speed);
        //Debug.Log("vel kunai: " + limit_speed);
        rb2d.velocity = new Vector2(limit_speed * -1f, rb2d.velocity.y);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.transform.position = inicio;
        }
    }

    void OnBecameInvisible()
    {
        this.transform.position = inicio;
    }
    public void reset()
    {
        this.transform.position = inicio;
    }
}

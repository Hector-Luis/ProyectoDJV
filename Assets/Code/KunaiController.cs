using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.left * speed * -1f);
        float limit_speed = Random.Range(speed,max_speed);
        //Debug.Log("vel kunai: " + limit_speed);
        rb2d.velocity = new Vector2(limit_speed * -1f, rb2d.velocity.y);
    }

    void OnBecameInvisible()
    {
        this.transform.position = inicio;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KunaiController kunai;
    public float speed = 2f;
    public float max_speed = 5f;
    public bool toca_suelo;
    public float fuerza_salto = 8.0f;
    public float t_kunai = 2f;
    public Transform trans;
    private Rigidbody2D rb2d;
    private Animator animator;
    private bool salto;
    private bool ataque;
    private float tiempo_ataque = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        toca_suelo = true;
        ataque = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocidad", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("toca_suelo", toca_suelo);
        

        if (Input.GetKeyDown(KeyCode.UpArrow) && toca_suelo){
            salto = true;
        }

        if (Input.GetKeyDown(KeyCode.Z) )
        {
            tiempo_ataque = 6.0f;
            animator.SetFloat("tiempo_ataque", Mathf.Abs(tiempo_ataque));
            ataque = true;
            animator.SetBool("ataque", ataque);
            Debug.Log("empieza ataque");
        }
        if (tiempo_ataque > 0.1f) {
            ataque = true;
            animator.SetFloat("tiempo_ataque", Mathf.Abs(tiempo_ataque));            
            tiempo_ataque -= 1.0f;
            Debug.Log("estan aqui 2 - tiempo: "+ tiempo_ataque);
        }
        else
        {
            ataque = false;
            animator.SetBool("ataque", ataque);
            animator.SetFloat("tiempo_ataque", Mathf.Abs(tiempo_ataque));
            Debug.Log("termina ataque");
            
        }

        //Invoke("Lanzar_kunai", t_kunai);
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);
       
        float limit_speed = Mathf.Clamp(rb2d.velocity.x, -max_speed, max_speed);
        rb2d.velocity = new Vector2(limit_speed, rb2d.velocity.y);

        if (h > 0.1f){
            this.transform.localScale = new Vector3(1f, 1f ,1f);
        }
        if (h < -0.1f)
        {
            this.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (salto) {
            rb2d.AddForce(Vector2.up * fuerza_salto, ForceMode2D.Impulse);
            salto = false;
        }
        if (ataque)
        {
            //animator.SetBool("ataque", true);
            //animator.SetTrigger("ataque");                
            Debug.Log("atacando");
            //ataque = false;
        }
        else { //animator.SetTrigger("descanso"); 
        }

    }

    void OnCollisionStay2D(Collision2D col){
        if (col.gameObject.tag == "suelo"){
            toca_suelo = true;            
        }
        if (col.gameObject.tag == "kunai")
        {
            this.transform.position = new Vector3(0, 6, 0);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "suelo")
        {
            toca_suelo = false;
        }
    }

    void OnBecameInvisible(){
        this.transform.position = new Vector3(0, 6, 0);
    }

    /*void Lanzar_kunai() {
        Instantiate(kunai);
    }*/

}

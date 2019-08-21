using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public KunaiController kunai;

    public GameObject salidaKunai, KunaiPlayer;

    public float walkingSpeed = 6f;
    public float max_speed = 5f;
    public bool toca_suelo;
    public float fuerza_salto = 8.0f;
    public float t_kunai = 2f;
    public Transform trans;
    public Vidas vidas;
    private Rigidbody2D rb2d;
    private Animator animator;
    private bool salto;
    private bool ataque;
    private float tiempo_ataque = 0.0f;
    private float vitalidad = 0.0f;
    public AudioClip espada_aire, espada_choque, auch;
    AudioSource sonido;


    ///variable para correr
    private bool corriendo = false;


    // Start is called before the first frame update
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
//
        salidaKunai = GameObject.Find("salida_kunai");
        KunaiPlayer = GameObject.Find("kunai_player");
//
        rb2d = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        vidas = GameObject.FindObjectOfType<Vidas>();
        sonido = gameObject.GetComponent<AudioSource>();
        toca_suelo = true;
        ataque = false;
        vitalidad = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocidad", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("toca_suelo", toca_suelo);
        animator.SetBool("ataque", ataque);
        animator.SetFloat("tiempo_ataque", Mathf.Abs(tiempo_ataque));
        animator.SetFloat("vitalidad", vitalidad);
        //tiempo_ataque -= 1.0f;

        if (Input.GetKeyDown(KeyCode.RightArrow) && toca_suelo)
        {
            if (corriendo)
            {
            }
            else { corriendo = true; NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer"); } //funcion notificacion para que el personaje empiese a correr
        }

        { // x-axis movement
            var v = rb2d.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += -walkingSpeed;
                rb2d.AddForce(Vector2.right * speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += walkingSpeed;
                rb2d.AddForce(Vector2.right * speed);
            }
            v.x = speed;
            rb2d.velocity = v;

            if (v.x > 0.1f)
            {
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (v.x < -0.1f)
            {
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        if (salto)
        {
            rb2d.AddForce(Vector2.up * fuerza_salto, ForceMode2D.Impulse);
            salto = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && toca_suelo){
            salto = true;
        }

        if (Input.GetKeyDown(KeyCode.Z) )
        {
            
            //tiempo_ataque = 0.0f;
            sonido.clip = espada_aire;
            sonido.Play();    
           // Debug.Log("empieza ataque nuevo");
            tiempo_ataque = 36.0f;
            //animator.SetFloat("tiempo_ataque", Mathf.Abs(tiempo_ataque));
            ataque = true;           
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject nuevaKunai = Instantiate(KunaiPlayer, salidaKunai.transform.position, gameObject.transform.rotation);
            
        }

        if (tiempo_ataque > 0.1f)
        {
            ataque = true;
            //animator.SetFloat("tiempo_ataque", Mathf.Abs(tiempo_ataque));            
            tiempo_ataque -= 1.0f;
            //Debug.Log("estan aqui 2 - tiempo: " + tiempo_ataque);
        }
        else
        {
            ataque = false;
        }

    }

    void OnCollisionStay2D(Collision2D col){
        if (col.gameObject.tag == "suelo"){
            toca_suelo = true;            
        }
        if (col.gameObject.tag == "arma_enemiga")
        {
            //sonido.Stop();
            if (ataque)
            {
                //
                sonido.Stop(); 
                sonido.clip = espada_choque;
                sonido.Play();  
                tiempo_ataque = 0.0f;              
                ataque = false;
            }
            else
            {
                sonido.clip = auch;
                sonido.Play();
                vitalidad -= 1.0f;
                
                if (vitalidad < 0.1f) {
                    vitalidad = 0.0f;
                    vidas.actualiza_vida(int.Parse(vitalidad + ""));                    
                    NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
                    GameObject personaje = GameObject.Find("Player");
                    GameObject.Find("Image").SetActive(false);
                    personaje.SetActive(false);
                }
                else
                {
                    vidas.actualiza_vida(int.Parse(vitalidad + ""));
                }
            }
        }
        if (col.gameObject.tag == "botiquin")
        {
            col.gameObject.SetActive(false);
            vitalidad += 1.0f;
            vidas.actualiza_vida(int.Parse(vitalidad + ""));           
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "suelo")
        {
            toca_suelo = false;
        }
    }

   /* void OnBecameInvisible(){
        this.transform.position = new Vector3(0, 6, 0);
        vitalidad -= 1.0f;
    }

    /*void Lanzar_kunai() {
        Instantiate(kunai);
    }*/

}

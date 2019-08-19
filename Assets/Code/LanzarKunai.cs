using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarKunai : MonoBehaviour
{
    public GameObject player, salidaKunai, kunaiPlayer;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        salidaKunai = GameObject.Find("salida_kunai");
        player = GameObject.Find("kunai_player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject nuevaKunai = Instantiate(kunaiPlayer, salidaKunai.transform.position, player.transform.rotation);
            rb2d = nuevaKunai.GetComponent<Rigidbody2D>();
            rb2d.AddRelativeForce(Vector2.right * 5f);
        }
    }
}

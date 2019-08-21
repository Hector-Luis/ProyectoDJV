using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarKunai_bk : MonoBehaviour
{
    public GameObject player, salidaKunai, KunaiPlayer;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        salidaKunai = GameObject.Find("salida_kunai");
        KunaiPlayer = GameObject.Find("Kunai_player");
        Debug.Log("bien hasta aqui");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject nuevaKunai = Instantiate(KunaiPlayer, salidaKunai.transform.position, player.transform.rotation);
            rb2d = nuevaKunai.GetComponent<Rigidbody2D>();
            rb2d.AddRelativeForce(Vector2.right * 5f);
        }
    }
}

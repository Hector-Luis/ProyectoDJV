using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{

    //public GameObject player;
    public Vector2 min_cam, max_cam;
    public Transform player;
    public float separacion = 7.46f;
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }



    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        /*if (player.position.y > 3.0f)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
            //transform.position = new Vector3(player.position.x + separacion, transform.position.y + 2.0f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + separacion, transform.position.y, transform.position.z);
        }*/
        //Debug.Log("posicion jugador es: " + player.position.y);
    }
    // Update is called once per frame
    /*void FixedUpdate()
    {
       
        float pos_x = player.transform.position.x;
        float pos_y = player.transform.position.y;

        this.transform.position = new Vector3(Mathf.Clamp(pos_x, min_cam.x, max_cam.x),
            Mathf.Clamp(pos_y, min_cam.y, max_cam.y), transform.position.z);
    
    }*/
}

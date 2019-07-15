using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    
    public GameObject player;
    public Vector2 min_cam, max_cam;
   

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        float pos_x = player.transform.position.x;
        float pos_y = player.transform.position.y;

        this.transform.position = new Vector3(Mathf.Clamp(pos_x, min_cam.x, max_cam.x),
            Mathf.Clamp(pos_y, min_cam.y, max_cam.y), transform.position.z);
    
    }
}

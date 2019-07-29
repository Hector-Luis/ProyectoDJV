using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vidas : MonoBehaviour
{
    public Sprite[] vidas;
    // Start is called before the first frame update
    void Start()
    {
        actualiza_vida(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void actualiza_vida(int pos)
    {
        this.GetComponent<Image>().sprite = vidas[pos];
    }
}

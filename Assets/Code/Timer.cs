using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text tiempoText;
    public float tiempo = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        tiempoText.text = "Time: " + tiempo.ToString("0") + " s";
    }
}

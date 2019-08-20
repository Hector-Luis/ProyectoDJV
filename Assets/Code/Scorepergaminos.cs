using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scorepergaminos : MonoBehaviour
{
    // Start is called before the first frame update
    public static Scorepergaminos instance;
    public TextMeshProUGUI text; // ui text donde se presenta el texto de total de pergaminos recojidos
    int score;
    void Start()
    {

        //se realiza la instancia para evitar el error del null
        if(instance == null)
        {
            instance = this;
        }
    }


    public void ChangeScore(int pergaValue)
    {

        // suma al score el parametro que le llega del script pergamino un entere que aomula 1 unto si
        //el jugador hace una colision con el perfabs pergamino
        score += pergaValue;
        text.text = "X" + score.ToString();


        /// if para cambiar de ecena segunel score de pergaminos
        if(score == 10)
        {
            SceneManager.LoadScene("WinScene");
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

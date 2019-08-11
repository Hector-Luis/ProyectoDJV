using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonJugar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    void OnMouseDown()
    {
        //Debug.Log("click");
        Application.LoadLevel ("GameScene");//paa cambiar de ecena revisar porque esta deprecado
    }
}

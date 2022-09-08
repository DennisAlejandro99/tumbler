using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager_text : MonoBehaviour
{
    public Text n_bala;
    private int numero = 5;
    // Start is called before the first frame update

    public void menos_bala() {
        numero = numero - 1;
    }
    public void muestra() {
        n_bala.text = "bala = " + numero;
    }
    void Start()
    {
        numero = 5;
    }

    // Update is called once per frame
    
}

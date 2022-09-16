using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bala : MonoBehaviour
{
    public float velocidad = 20;    
    Rigidbody2D rb;
    manager_text manager;
    public GameObject jugador;
    private int colision=0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
        manager = FindObjectOfType<manager_text>(); 
    }
    // Update is called once per frame
    void Update()
    {
       rb.velocity = new Vector2(velocidad, 0); //estamos controlando la fisica de la bala
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        colision++;
        Debug.Log("collision bullet " + colision);
        //colision = colision + 1;
        //Debug.Log("colli : "+ colision);
        if (collision.gameObject.name == "zombie" )
        {
            //Debug.Log("colli : tab");
            //manager.sumar_puntos();
           // manager.muestra_puntos();
            Destroy(collision.gameObject); //destrulles al objeto con quien colisionaste
            manager.sumar_puntos();
            manager.muestra_puntos();
             //  y te destruyes tu mismo 
             
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidad = 20;
    Rigidbody2D rb;
    //public Text score_text;
    
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidad, 0); //estamos controlando la fisica de la bala 

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            Destroy(collision.gameObject); //destrulles al objeto con quien colisionaste
            Destroy(this.gameObject); //  y te destruyes tu mismo
        }
    }
}


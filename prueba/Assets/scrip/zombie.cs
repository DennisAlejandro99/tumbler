using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    int meta;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //toda la fisica 
        sr = GetComponent<SpriteRenderer>();//todo lo que se ve
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(meta, rb.velocity.y);
        if (meta == 10) {
            rb.velocity = new Vector2(-10, rb.velocity.y);

        }
        
    }
}

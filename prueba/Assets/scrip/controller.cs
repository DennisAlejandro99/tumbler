using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 10;

    public bool puedeSaltar = false;

    public float fuerzaSalto = 10;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    void Start()
    {
        Debug.Log("Este es un nuevo mensaje");
        rb = GetComponent<Rigidbody2D>();//esto sirve para poder darle un valor inicial
        sr = GetComponent<SpriteRenderer>();//esto sirve para poder darle un valor inicial
        animator = GetComponent<Animator>();//esto sirve para poder darle un valor inicial
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("Estado", 0);
        if (Input.GetKey(KeyCode.RightArrow)) {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);//que la velocidad cambie
            sr.flipX = false;
            animator.SetInteger("Estado", 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            sr.flipX = true;
            animator.SetInteger("Estado", 1);
        }
        if (Input.GetKeyUp(KeyCode.Space) && puedeSaltar) {
            rb.AddForce(Vector2.up * fuerzaSalto , ForceMode2D.Impulse);
            puedeSaltar = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // si hay colision  entonces entra aqui 
    {
        puedeSaltar = true;
        if (collision.gameObject.tag == "enemy") { 
            Debug.Log("estas muerto");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    //Start is called before the first frame update
    public float velocidad = 8;
    public GameObject bala;
    //public bala bala_controller;
    public bool puedeSaltar = true, salto_temp = true;

    public int cont_sal = 0;
    public float fuerzaSalto = 10;

    private Vector3 lastcheckposition;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    public int turno = 0;


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

        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        if (puedeSaltar==true)
            {
                Debug.Log("correr");
                animator.SetInteger("Estado",0);
            }

        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
            {
            puedeSaltar = false;
            Debug.Log("false");
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetInteger("Estado",1);
            
            }

        //bala

        if (Input.GetKeyUp(KeyCode.X))
        {
                var balaPosition = transform.position + new Vector3(5, 0, 0); // que ta lejos esta del disparo de la bola 
                Instantiate(bala, balaPosition, Quaternion.identity);

        }
    }
    private void OnCollisionEnter2D(Collision2D other) // si hay colision  entonces entra aqui 
    {
        Debug.Log("true");

        puedeSaltar = true;
    }



}

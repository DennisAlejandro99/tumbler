using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    //Start is called before the first frame update
    public float velocidad = 8;
    public GameObject bala;

    //hongo 
    public GameObject hongo;

    //bala 
    bala bal;
    private manager_text manager;
    int contador = 1 ;
    //public bala bala_controller;
    public bool puedeSaltar = true, salto_temp = true;
    //audio
    public AudioClip jump;
    public AudioClip ataque;
    AudioSource audiosource;

    public int cont_sal = 0;
    public float fuerzaSalto = 10;

    private Vector3 lastcheckposition;
    Transform op;
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
        manager = FindObjectOfType<manager_text>();
        audiosource =  GetComponent<AudioSource>();
        op = GetComponent<Transform>();
        bal = FindObjectOfType<bala>();
    }


    // Update is called once per frame
    void Update()
    {
        //parado
        rb.velocity = new Vector2(0, rb.velocity.y); //la velocidad inial es en 0  en x y en y por defecto
        if (puedeSaltar)
        {
            animator.SetInteger("Estado", 0);

        }
        
        //salta 
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
            {
            audiosource.PlayOneShot(jump);
            puedeSaltar = false;
            Debug.Log("false");
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetInteger("Estado",2);
            
            }

        //bala

        if (Input.GetKeyUp(KeyCode.X))
        {
            if (contador<=5) {
                audiosource.PlayOneShot(ataque);
                var balaPosition = transform.position + new Vector3(5, 0, 0); // que ta lejos esta del disparo de la bola 
                Instantiate( bala, balaPosition, Quaternion.identity);
                //manager.muestra();
                contador++;
                
            } 
        }
        if (Input.GetKey(KeyCode.R))
        {
            animator.SetInteger("Estado", 2);
        }

        //correr
        if (Input.GetKey(KeyCode.RightArrow)) //cuando mantengo presionado la tecla derecha 
        {
            //Debug.Log("Entro");
            rb.velocity = new Vector2(10, rb.velocity.y);
            animator.SetInteger("Estado", 1);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //cuando mantengo presionado la tecla derecha 
        {
            rb.velocity = new Vector2(-10, rb.velocity.y);
            animator.SetInteger("Estado", 1);
            sr.flipX = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D other) // si hay colision  entonces entra aqui 
    {
        Debug.Log("true");

        puedeSaltar = true;
         
        if (other.gameObject.name=="gold") {
            Destroy(other.gameObject);
            manager.suma_puntos_gold();
            manager.muestra_moneda_gold();
            //this.transform.localScale = new Vector3(2f,2f,2f); //para cambiar el tamaño del mismo objeto
            //hongo.transform.localScale = new Vector3(4f,4f,4f); //para agrandar otro objeto
        }
        if (other.gameObject.name == "silver")
        {
            Destroy(other.gameObject);
            manager.suma_puntos_silver();
            manager.muestra_moneda_silver();
            //this.transform.localScale = new Vector3(2f,2f,2f); //para cambiar el tamaño del mismo objeto
            //hongo.transform.localScale = new Vector3(4f,4f,4f); //para agrandar otro objeto
        }
        if (other.gameObject.name == "bronze")
        {
            Destroy(other.gameObject);
            manager.suma_puntos_bronze();
            manager.muestra_moneda_bronze();
            //this.transform.localScale = new Vector3(2f,2f,2f); //para cambiar el tamaño del mismo objeto
            //hongo.transform.localScale = new Vector3(4f,4f,4f); //para agrandar otro objeto
        }
        if (other.gameObject.name == "zombie")
        {
            Destroy(other.gameObject);
            manager.suma_puntos_bronze();
            manager.muestra_moneda_bronze();
            //this.transform.localScale = new Vector3(2f,2f,2f); //para cambiar el tamaño del mismo objeto
            //hongo.transform.localScale = new Vector3(4f,4f,4f); //para agrandar otro objeto
        }
        if (other.gameObject.name == "tab")
        {
            manager.SaveGame();
            //this.transform.localScale = new Vector3(2f,2f,2f); //para cambiar el tamaño del mismo objeto
            //hongo.transform.localScale = new Vector3(4f,4f,4f); //para agrandar otro objeto
        }

        
    }
}

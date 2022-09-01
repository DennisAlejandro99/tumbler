using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    //Start is called before the first frame update
    public float velocidad = 10;

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

        rb.velocity = new Vector2(0, rb.velocity.y);
        //if (salto_temp) {
        if (puedeSaltar)
        {
            animator.SetInteger("Estado", 0);
        }

        //}
        //posicion 20
        //derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("corre");
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            sr.flipX = false;
            animator.SetInteger("Estado", 1);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X)) // al precionar no importa el orden
        {


            rb.velocity = new Vector2(velocidad * 2, rb.velocity.y);//que la velocidad cambie
            sr.flipX = false;
            animator.SetInteger("Estado", 1);
        }
        //izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            sr.flipX = true;
            animator.SetInteger("Estado", 1);


        }
        if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad * 2, rb.velocity.y);//que la velocidad cambie
            sr.flipX = true;
            animator.SetInteger("Estado", 1);

        }
        //

        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            animator.SetInteger("Estado", 2);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            puedeSaltar = false;


        }

        //if (puedeSaltar != false)
        //   {
        //       rb.velocity = new Vector2(0, rb.velocity.y);
        //       animator.SetInteger("Estado", 0);
        //   }
    }

    private void OnCollisionEnter2D(Collision2D other) // si hay colision  entonces entra aqui 
    {

        puedeSaltar = true;
        //Debug.Log("estas muerto");
        if (other.gameObject.tag == "piso")
        {
            Debug.Log("estas en el suelo");
        }
        if (other.gameObject.name == "muerte")
        {
            if (lastcheckposition != null)
            {
                transform.position = lastcheckposition;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "regreso1") //esto tambien se puede hacer en onCollision
        {
            Debug.Log("bandera");
            lastcheckposition = transform.position;
        }
        if (other.gameObject.name == "regreso2") //esto tambien se puede hacer en onCollision
        {
            Debug.Log("bandera");
            lastcheckposition = transform.position;
        }

    }
}

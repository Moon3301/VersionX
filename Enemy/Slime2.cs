using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime2 : MonoBehaviour
{
    // Start is called before the first frame update
    public static Slime2 instance;
    private Rigidbody2D rb;

    public float speed;

    public Animator animator;

    private float LastShoot;

    public float JumpForce;

    private bool Grounded;

    public GameObject player;

    public float distancex;

    //anim

    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public GameObject dialog4;

    public float time = 25;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();

        dialog1.SetActive(false);
        dialog2.SetActive(false);
        dialog3.SetActive(false);
        dialog4.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player == null) return;

        // Distancia entre jugador y enemigo
        distancex = Mathf.Abs(player.transform.position.x - transform.position.x);

        // Validar Grounded
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.7f))
        {
            Grounded = true;
        }
        else Grounded = false;

        //Salto
        if(Grounded){
            Jump();
        }


        //Attack

        if(distancex < 3.5f){
            animator.SetBool("Attack", true);
        }

        if(distancex > 3.6f){
            animator.SetBool("Attack", false);
        }

    }


    private void Jump(){

        Vector2 objetivo = new Vector2(player.transform.position.x, player.transform.position.y);

        rb.AddForce(Vector2.up  * JumpForce);

        if(distancex < 7f){

            rb.AddForce(player.transform.position - transform.position * 0.5f);
           
        }

    }

    void textDialog(){

        time -= Time.deltaTime;

        if(time <15){
            dialog1.SetActive(true);
            dialog2.SetActive(false);
            dialog3.SetActive(false);
            dialog4.SetActive(false);
        }
        if(time <10){
            dialog2.SetActive(true);
            dialog1.SetActive(false);
            dialog3.SetActive(false);
            dialog4.SetActive(false);

        }
        if(time <5){
            dialog3.SetActive(true);
            dialog1.SetActive(false);
            dialog2.SetActive(false);
            dialog4.SetActive(false);
        }
        if(time <0){
            dialog4.SetActive(true);
            dialog1.SetActive(false);
            dialog2.SetActive(false);
            dialog3.SetActive(false);
            time = 25;
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slime : MonoBehaviour
{

    public float typeSlime;
    public float HP;
    public static Slime instance;
    private Rigidbody2D rb;

    public float speed;

    public Animator animator;

    private float LastShoot;

    public float JumpForce;

    private bool Grounded;

    public GameObject player;

    public float distancex;

    public GameObject destroyEffect;

    public GameObject textDamage;

    public bool Attack;

    private Vector3 direction;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Attack = animator.GetBool("Attack");

        direction = player.transform.position - transform.position;

        if(typeSlime != 2){

            if(direction.x >= 0.0f){
                transform.localScale = new Vector3(1,1,1);
            }
            else{
                transform.localScale = new Vector3(-1,1,1);
            }

        }

        

        // Distancia entre jugador y enemigo
        distancex = Mathf.Abs(player.transform.position.x - transform.position.x);

        // Validar Grounded
        Debug.DrawRay(transform.position, Vector3.down * 0.7f, Color.red);
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

        if(distancex < 5f){
            animator.SetBool("Attack", true);
        }

        if(distancex > 5.1f){
            animator.SetBool("Attack", false);
        }

        Debug.Log(distancex);
    }

    

    private void Jump(){

        Vector2 objetivo = new Vector2(player.transform.position.x, player.transform.position.y);

        rb.AddForce(Vector2.up  * JumpForce);

       

        if(distancex < 7f){

        rb.AddForce(player.transform.position - transform.position * 0.3f);

            if(typeSlime == 2){
                if(distancex < 6f){
                    rb.AddForce(-player.transform.position - transform.position * 0.3f);
                }
            }
           
        }
 
        

      

        

    }

    public void Hit(float damage){
        

        HP = HP - damage;

        GameObject textGo =  Instantiate(textDamage, transform.position + new Vector3(0,0.8f,0), Quaternion.identity);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);
        
        if(HP <= 0){
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    

    
}

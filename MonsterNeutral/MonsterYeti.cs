using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterYeti : MonoBehaviour
{
    // Start is called before the first frame update
    public static MonsterYeti instance;

    public GameObject objetivo;

    //fisicas
    public Rigidbody2D rb;
    private bool Grounded;
    public Animator animator;

    // Stats
    public float Health;

    private float LastShoot;

    public float velocity;

    public float distancex;

    public GameObject destroyEffect;

    private float Direction;

    private Vector3 direction;
    // text damage

    public GameObject textDamage;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Jump Monster
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.3f)){
            Grounded = true;
        }
        else{
            Grounded = false;
        }

        if(Grounded){
            JumpMonster();
        }
        // Distancia
        distancex = Mathf.Abs(objetivo.transform.position.x - transform.position.x);

        

        // Direccion personaje
        direction = objetivo.transform.position - transform.position;

        if (direction.x >= 0.9f){
            transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
            Direction = 1f;
        }  
        else {
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            Direction = -1f;
        }

        //Ataque
        if (distancex < 5f && Time.time > LastShoot + 2f){



            Attack();

            LastShoot = Time.time;

        }
        
    }

    private void FixedUpdate(){
        
        rb.velocity = direction * velocity;
    }

    public void JumpMonster(){
        rb.AddForce(new Vector2(0, 30));
    }

    public void Attack(){
        animator.SetBool("attack", true);



    }
}

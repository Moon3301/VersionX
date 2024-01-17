using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHorde : MonoBehaviour
{

    //Tipo personaje
    public float HordeType;

    public GameObject Horde1;
    public GameObject Horde2;
    public GameObject Horde3;

    //enemy
    public GameObject player;
    
    // Direccion personaje
    private Vector3 Direction;

    // Instanciar personaje
    public static EnemyHorde instance;

    // weapon
    public GameObject bullet;
    private float LastShoot;
    
    //fisicas
    public Rigidbody2D rb;
    private GameObject position;
    public float velocity;
    public float distancex;

    //animacion
    public Animator animator;

    // Stats
    public float Health;

    



    public GameObject destroyEffect;

    private float time = 1f;

    // text damage

    public GameObject textDamage;
    // Start is called before the first frame update

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {


        
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));

        // Obtiene la distancia entre el personaje y el enemigo
        distancex = Mathf.Abs(player.transform.position.x - transform.position.x);
        animator.SetFloat("speed",-1f);
        // Si la distancia es menor el persoanje se mueve hacia el enemigo
        Vector2 objetivo = new Vector2(player.transform.position.x, player.transform.position.y);
        
        if( distancex < 10f){





        }

        if (distancex < 5.0f){

            animator.SetFloat("speed",1f);
            
            Vector2 nuevapos = Vector2.MoveTowards(rb.position, objetivo, velocity * Time.deltaTime); 
            rb.MovePosition(nuevapos);

            if(distancex < 2f){

                Vector2 nuevapos2 = Vector2.MoveTowards(rb.position, objetivo + new Vector2(7f,0f), velocity * Time.deltaTime); 
                rb.MovePosition(nuevapos2);

            }

        }


        // Obtiene la direccion del personaje
        Vector3 direction = player.transform.position - transform.position;

        // Si el personaje esta a la izquierda del enemigo, cambia su localScale
        if (direction.x >= 0.9f){
            position.transform.localScale = new Vector3(1f, -1f, 1f);
        }  
        else {
            position.transform.localScale = new Vector3(1f, 1f, 1f);
        }


        // Condiciona el tipo de personaje para lanzar un ataque
        if(HordeType == 1){

            if(distancex < 4.5f && Time.time > LastShoot + 1f){
                animator.SetBool("attack", true);

                ShootType1();

                LastShoot = Time.time;
            }

        }

        if(HordeType == 2){

            if(distancex < 4.5f && Time.time > LastShoot + 2f){
                animator.SetBool("attack", true);

                ShootType2();

                LastShoot = Time.time;
            }

        }




        
    }

    public void ShootType1(){


    }


    public void ShootType2(){



    }

    public void Hit(float damage){

        Health = Health - damage;

        GameObject textGo =  Instantiate(textDamage, position.transform.position + new Vector3(0.5f,1.2f,0) , Quaternion.identity);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);

        if(Health <= 0){
            Instantiate(destroyEffect, position.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void AttackFalse(){
        animator.SetBool("attack", false);
    }
}

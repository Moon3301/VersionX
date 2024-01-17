using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMecha : MonoBehaviour
{

    public float MechaType;
    public GameObject player;
    
    // Direccion personaje

    // Instanciar personaje
    public static EnemyMecha instance;

    // weapon
    public GameObject bullet;
    
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
    // text damage

    public GameObject textDamage;
    // Start is called before the first frame update


    public bool force = false;

    public float time ;

    private void Awake(){
        instance = this;
    }
    void Start()
    {

        
    }


    // Update is called once per frame
    void Update()
    {
        
        

        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));


        distancex = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (distancex < 10f && distancex > 5f){

            Vector2 objetivo = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 nuevapos = Vector2.MoveTowards(rb.position, objetivo, velocity * Time.deltaTime); 
            rb.MovePosition(nuevapos);
        }

        // Direccion personaje
        Vector3 direction = player.transform.position - transform.position;

        if (direction.x >= 0.9f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }  
        else {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (distancex < 5f && Time.time > LastShoot + 2f){

            animator.SetBool("attack", true);
            if(MechaType == 1){
                ShootType1();
            }
            
            if(MechaType == 2){
                ShootType2();
            }


            LastShoot = Time.time;
        }

        MoveSpeed();
        
    }



    public void ShootType1(){

        Vector3 direction;
        if(transform.localScale.x == -1f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bulletInstance = ScorpionObjectPooling.instance.requestBullet();
        bulletInstance.transform.position = transform.position + new Vector3(-0.5f,0.6f,0);
        bulletInstance.GetComponent<BulletEnemyMechaScorpion>().SetDirection(direction);


        /*GameObject bulletInstance = Instantiate(bullet, transform.position + new Vector3(-0.5f,0.6f,0), Quaternion.identity);
        bulletInstance.GetComponent<BulletEnemyMechaScorpion>().SetDirection(direction);
        */

    }

    public void ShootType2(){

        Vector3 direction;
        if(transform.localScale.x == -1f) direction = Vector3.right;
        else direction = Vector3.left;


        GameObject bulletInstance = SnakeObjectPooling.instance.requestBullet();
        bulletInstance.transform.position = transform.position;
        bulletInstance.GetComponent<BulletEnemyMechaScorpion>().SetDirection(direction);

        /*
        GameObject bulletInstance = Instantiate(bullet, transform.position + new Vector3(0,0,0), Quaternion.identity);
        bulletInstance.GetComponent<BulletEnemyMechaScorpion>().SetDirection(direction);
        */



    }

    public void Hit(float damage){

        Health = Health - damage;

        force = true;

        GameObject textGo = TextDamagePool.instance.requesText();
        textGo.transform.position = transform.position + new Vector3(0,1f,0);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);

        if(Health <= 0){
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void MoveSpeed(){

        if(force == true){

            time -= Time.deltaTime;

            Vector3 direction;
            if(transform.localScale.x == 1f) direction = Vector3.right;
            else direction = Vector3.left;
            
            rb.velocity =  new Vector2(3f * direction.x, rb.velocity.y);
           

            if(time < 0){
                force = false;
                time = 0.5f;
                rb.velocity = new Vector2(0,0);
            }
        }

    }

    

    public void AttackFalse(){
        animator.SetBool("attack", false);
    }
}

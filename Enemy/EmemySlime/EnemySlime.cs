using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemySlime : MonoBehaviour
{
    public float SlimeType;
    public GameObject player;
    
    // Direccion personaje

    // Instanciar personaje
    public static EnemySlime instance;
    
    //fisicas
    public Rigidbody2D rb;
    private bool Grounded;
    public Animator animator;

    public float JumpForce;

    private float LastJump;

    // Stats
    public float Health;

    public float DEF;

    private float LastShoot;

    public float speed;

    public float distancex;

    private float distance;
    private bool force = false;

    private float time ;

    //public float damage;
    private float val = 0;

    private float closeUp;

    public GameObject symbolExclamation;

    // move repulse
    public bool ActiveforceRepulse;
    public float timeRepulse;

    public float moveForce;

    private void Awake(){
        instance = this;
    }

    void Start()
    {
        Health = gameObject.GetComponent<StatsEnemy>().HP;
        DEF = gameObject.GetComponent<StatsEnemy>().DEF; 
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void OnEnable() {

        player = GameObject.FindGameObjectWithTag("Player");
        Health = gameObject.GetComponent<StatsEnemy>().HP;
        DEF = gameObject.GetComponent<StatsEnemy>().DEF;
        symbolExclamation.SetActive(true);
        
    }

    private void OnDisable(){

        player = GameObject.FindGameObjectWithTag("Player");
        symbolExclamation.SetActive(false);
        
    }

    // Update is called once per frame
    void Update(){

        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null){

            distance = player.transform.position.x - transform.position.x;

            distancex = Mathf.Abs(player.transform.position.x - transform.position.x);

            //Jump
            if(Physics2D.Raycast(transform.position, Vector3.down, 0.2f)){
                Grounded = true;
            }else{
                Grounded = false;
            }

            if(Grounded){

                Jump();
    
            }

            if(distance > 0){
                transform.localScale = new Vector3(-1.5f,1.5f,1.5f);
                transform.GetChild(1).localScale = new Vector3(-1,1,1); // Obtiene Scale de LVL
            }else{
                transform.localScale = new Vector3(1.5f,1.5f,1.5f);
                transform.GetChild(1).localScale = new Vector3(1,1,1); // Obtiene Scale de LVL
            }

            // follow player

            if(SlimeType == 1){

                closeUp = 0.5f;
                follow();

                if(distancex <2f){
                animator.SetBool("attack",true);
                }

            }

            if(SlimeType == 2){

                if(distancex < 8f){
                    
                    animator.SetBool("attack",true);
                    Shoot();
                }

                closeUp = 7f;
                follow();
                
            }

            if(SlimeType == 3){
                closeUp = 3f;
                follow();

            }

            MoveRepulse();

        }
        
    }

    public void MoveRepulse(){

        if(ActiveforceRepulse == true){

            timeRepulse -= Time.deltaTime;

            if(distance > 0){
                rb.AddForce(Vector2.left * moveForce);
            }else if(distance < 0){
                rb.AddForce(Vector2.right * moveForce);
            }

            if(timeRepulse <= 0 ){
                ActiveforceRepulse = false;
                timeRepulse = 0.2f;
            }
        }

    }

    public void StartForceRepulse(){
        ActiveforceRepulse = true;
    }

    public void Shoot(){

        Vector3 direction;
        if(distance > 0) direction = Vector3.right;
        else direction = Vector3.left;

        if(Time.time > LastShoot + 2f){

            GameObject bulletInstance = BulletPoolingEnemy.instance.requestBullet();
            bulletInstance.transform.position = transform.position + new Vector3(0,0.5f,0);
            bulletInstance.GetComponent<EnemyBullet>().SetDirection(direction);
            bulletInstance.GetComponent<EnemyBullet>().damage = gameObject.GetComponent<StatsEnemy>().ATK;

            LastShoot = Time.time;
        }

    }

    public void DesactivateAttack(){
        animator.SetBool("attack",false);
    }

    private void follow(){

        if (distancex < 8f && distancex > closeUp){
            
            //direccion slime
            if(distance > 0){
            val = 1; // derecha
            }else{
                val =-1; // izquierda
            }

        }else{
            
            val = 0;
        }

    }

    private void FixedUpdate(){
        
    }

    private void Jump(){

        rb.velocity = new Vector2(val * JumpForce , 1 * speed );

    }

    public void Hit(float damage){
        
        //enemy less Health
        damage -= DEF;

        if(damage <= 0){
            damage = 1;
        }

        //gameObject.GetComponent<StatsEnemy>().HP -= damage;
        Health -= damage;

        //text damage
        GameObject textGo = TextDamagePool.instance.requesText();
        textGo.transform.position = transform.position + new Vector3(0,2f,0);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);
        
        //effect damage 

        GameObject effectTextDamage =  effectPoolDamage.instance.requestBullet();
        effectTextDamage.transform.position = transform.position;

        // enemy death
        if(Health <= 0){
            //Instantiate(destroyEffect, transform.position, Quaternion.identity);

            //Efecto de muerte
            GameObject effectEdeath = EffectDeathPool.instance.requestBullet();
            effectEdeath.transform.position = transform.position;
            
            // Aumento EXP Player
            Stats.instance.EXP += gameObject.GetComponent<StatsEnemy>().LVL;
            Stats.instance.CURRENTMP += gameObject.GetComponent<StatsEnemy>().LVL;
            PlayerW.instance.CountEnemyDefeat += 1;
            
            // Desactivar objeto
            gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.tag == "AttackSword"){
            Hit(2);
        }

    }
 
}

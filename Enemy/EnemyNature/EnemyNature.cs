using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyNature : MonoBehaviour
{
    public float NatureType;
    public GameObject player;

    // Instanciar personaje
    public static EnemyNature instance;
    
    //fisicas
    public Rigidbody2D rb;
    public Animator animator;

    // Stats
    public float Health;
    private float LastShoot;
    public float velocity;
    public float distancex;
    public GameObject destroyEffect;
    private float time = 1f;

    // text damage
    public GameObject textDamage;

    //

    public GameObject pos;

    // Start is called before the first frame update
    private void Awake(){
        instance = this;
    }
    void Start()
    {
        Health = gameObject.GetComponent<StatsEnemy>().HP;
    }

    // Update is called once per frame
    void Update()
    {
        //Direction = player.transform.position - transform.position;
        //Obtiene la posicion del bone 0 del personaje 
        
        //Asigna la velocidad de movimiento a la variable speed de animator
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));

        // Calcula la distancia entre el juegador y el personaje
        distancex = Mathf.Abs(player.transform.position.x - transform.position.x);
        animator.SetFloat("speed",-1f);

        // Si la distancia es menor a 8 se mueve hacia el jugador
        if (distancex < 10f && distancex > 2f){

            animator.SetFloat("speed",1f);

            Vector2 currentpos = transform.position;
            Vector2 objetivo = new Vector2(player.transform.position.x, player.transform.position.y);
            
            objetivo.y = rb.position.y;
            
            Vector2 nuevapos = Vector2.MoveTowards(rb.position, objetivo, velocity * Time.deltaTime); 
            rb.MovePosition(nuevapos);
            
        }

        Vector3 direction = player.transform.position - transform.position;
   
        if (direction.x > 0f){
            pos.transform.localScale = new Vector3(1f, -1f, 1f);
        }  
        else {
            pos.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if(NatureType == 1){

            if(distancex < 3f && Time.time > LastShoot + 2.5f){
                
                animator.SetBool("attack", true);
                LastShoot = Time.time;
            }

        }else if (NatureType == 2){

            if (distancex < 15f && Time.time > LastShoot + 2f){
                animator.SetBool("attack", true);
                if(NatureType == 2){
                    ShootType2();
                }

                LastShoot = Time.time;
            }

        }

    }

    public void StopAction(){
        velocity = 0;
    }

    public void ActiveAction(){
        velocity = 5f;
    }

    public void ShootType1(){

        Vector3 direction;
        if(pos.transform.localScale.y == -1f) direction = new Vector3(2f,-2.5f,0);
        else direction = new Vector3(-2f,-2.5f,0);

        GameObject bulletClone = DaidarabotchiObjectPooling.instance.requestBullet();
        bulletClone.transform.position = transform.position + direction;
        bulletClone.GetComponent<AttackEnemyNature2>().GetDamage(gameObject.GetComponent<StatsEnemy>().ATK);

        /*
        Instantiate(bullet, transform.position + direction, Quaternion.identity);
        */
    }

    public void ShootType2(){

        Vector3 direction;
        if(pos.transform.localScale.y == -1f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bulletClone = ArbolObjectPooling.instance.requestBullet();
        bulletClone.transform.position = transform.position + new Vector3(0,3f,0);

        bulletClone.GetComponent<BulletEnemyNature>().SetDirection(Vector3.up + direction);
        bulletClone.GetComponent<BulletEnemyNature>().GetPosition(PlayerW.instance.transform.position, transform.position+ new Vector3(0,3f,0));
        bulletClone.GetComponent<BulletEnemyNature>().GetDamage(gameObject.GetComponent<StatsEnemy>().ATK);
        /*
        GameObject bulletClone1 = ArbolObjectPooling.instance.requestBullet();
        bulletClone1.transform.position = transform.position + new Vector3(0,2f,0);
        bulletClone1.GetComponent<BulletEnemyNature>().SetDirection(Vector3.up + direction);
        bulletClone1.GetComponent<BulletEnemyNature>().GetPosition(PlayerW.instance.transform.position+ new Vector3(1f,0,0), transform.position+ new Vector3(0,2f,0));

        GameObject bulletClone2 = ArbolObjectPooling.instance.requestBullet();
        bulletClone2.transform.position = transform.position + new Vector3(0,4f,0);
        bulletClone2.GetComponent<BulletEnemyNature>().SetDirection(Vector3.up + direction);
        bulletClone2.GetComponent<BulletEnemyNature>().GetPosition(PlayerW.instance.transform.position + new Vector3(2f,0,0), transform.position+ new Vector3(0,4f,0));
        */

        /*
        GameObject bulletInstance1 = Instantiate(bullet, transform.position + new Vector3(0,3f,0), Quaternion.identity);
        bulletInstance1.GetComponent<BulletEnemyNature>().SetDirection(Vector3.up + direction);
        bulletInstance1.GetComponent<BulletEnemyNature>().GetPosition(PlayerW.instance.transform.position, transform.position+ new Vector3(0,3f,0));
        
        GameObject bulletInstance2 = Instantiate(bullet, transform.position + new Vector3(0,2f,0), Quaternion.identity);
        bulletInstance2.GetComponent<BulletEnemyNature>().SetDirection(Vector3.up + direction);
        bulletInstance2.GetComponent<BulletEnemyNature>().GetPosition(PlayerW.instance.transform.position+ new Vector3(1f,0,0), transform.position+ new Vector3(0,2f,0));
        
        GameObject bulletInstance3 = Instantiate(bullet, transform.position + new Vector3(0,4f,0), Quaternion.identity);
        bulletInstance3.GetComponent<BulletEnemyNature>().SetDirection(Vector3.up + direction);
        bulletInstance3.GetComponent<BulletEnemyNature>().GetPosition(PlayerW.instance.transform.position + new Vector3(2f,0,0), transform.position+ new Vector3(0,4f,0));
        */
    }

    public void Hit(float damage){

        damage -= gameObject.GetComponent<StatsEnemy>().DEF;

        if(damage <= 0){
            damage = 1;
        }

        Health -= damage;
        
        //text damage
        GameObject textGo = TextDamagePool.instance.requesText();
        textGo.transform.position = transform.position + new Vector3(0,0.5f,0);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);

        //effect damage 

        GameObject effectTextDamage =  effectPoolDamage.instance.requestBullet();
        effectTextDamage.transform.position = transform.position;

        animator.SetBool("TakeDamage",true);

        /*GameObject textGo =  Instantiate(textDamage, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);
        */

        if(Health <= 0){

            GameObject effectEdeath = EffectDeathPool.instance.requestBullet();
            effectEdeath.transform.position = transform.position;

            Stats.instance.EXP += gameObject.GetComponent<StatsEnemy>().LVL;
            Stats.instance.CURRENTMP += gameObject.GetComponent<StatsEnemy>().LVL;
            PlayerW.instance.CountEnemyDefeat += 1;

            gameObject.SetActive(false);
        }
    }

    public void TakeDamageFalse(){
        animator.SetBool("TakeDamage",false);
    }

    public void AttackFalse(){
        animator.SetBool("attack", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBoss1 : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyBoss1 instance;
    public Animator animator;

    public GameObject player;

    public float distancex;

    private float LastShoot;
    private float LastShootUltimate;

    public GameObject ultimateAttack;

    public float timeActivateShield =5f;

    public float timeUltimateAttack = 15f;

    private bool activeUtlimateAttack = false;
    private Vector3 directionBulletUltimate;
    private float countDirection;

    private bool DirectionPositive = true;
    private bool DirectionNegative = false;

    // symbol

    private bool activeSymbol;
    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        distancex = Mathf.Abs(player.transform.position.x - transform.position.x);

        if(distancex < 30f && Time.time > LastShoot + 2f){

            ShootType1();
            ShootType2();

            LastShoot = Time.time;
        }

        if(Boss1Shield.instance.gameObject.activeSelf == false){
            Debug.Log("ESCUDO DESACTIVADO");

            
            

            timeActivateShield -= Time.deltaTime;

            if(timeActivateShield < 0){
                Boss1Shield.instance.gameObject.SetActive(true);
                timeActivateShield = 5f;
            }

        }

        

        if(activeUtlimateAttack == false){
            timeUltimateAttack -= Time.deltaTime;

            if(timeUltimateAttack <= 0){
                activeUtlimateAttack = true;
                timeUltimateAttack = 10f;
            }
        }

        if(activeUtlimateAttack == true){
            timeUltimateAttack -= Time.deltaTime;

            if(timeUltimateAttack <= 0){
                activeUtlimateAttack = false;
                timeUltimateAttack = 10f;
            }
        }



        if(activeUtlimateAttack == true){

            if(Time.time > LastShootUltimate + 0.5f){
            
            if(countDirection <= 1 && DirectionPositive == true){
                countDirection += 0.2f;

            }else{
                DirectionNegative = true;
                DirectionPositive = false;
            } 
            
            if(countDirection >= 0 && DirectionNegative == true){
                countDirection -= 0.2f;
            }else{
                DirectionNegative = false;
                DirectionPositive = true;
            }

            directionBulletUltimate = new Vector3(0,countDirection,0);

            ShootUltimate(directionBulletUltimate);

            LastShootUltimate = Time.time;



        }

    }

        

        
    }

    

    void NatureMissile(){

        GameObject missile = NatureMissilePool.instance.requestMissile();
        missile.transform.position = transform.position;

    }

    void ShootType1(){

        Vector3 direction;
        if(transform.localScale.x == -1f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject missile = NatureMissilePool.instance.requestMissile();
        missile.transform.position = transform.position + new Vector3(-7f,3f,0);
        missile.GetComponent<NatureMissile>().SetDirection(Vector3.up + Vector3.left);
        missile.GetComponent<NatureMissile>().GetPosition(PlayerW.instance.transform.position + new Vector3(1f,0,0),transform.position);
        
        GameObject missile1 = NatureMissilePool.instance.requestMissile();
        missile1.transform.position = transform.position + new Vector3(-7f,3.5f,0);
        missile1.GetComponent<NatureMissile>().SetDirection(Vector3.up + Vector3.left);
        missile1.GetComponent<NatureMissile>().GetPosition(PlayerW.instance.transform.position + new Vector3(-1f,0,0),transform.position);

        GameObject missile2 = NatureMissilePool.instance.requestMissile();
        missile2.transform.position = transform.position + new Vector3(-7f,4f,0);
        missile2.GetComponent<NatureMissile>().SetDirection(Vector3.up + Vector3.left);
        missile2.GetComponent<NatureMissile>().GetPosition(PlayerW.instance.transform.position + new Vector3(2f,0,0),transform.position);

        GameObject missile3 = NatureMissilePool.instance.requestMissile();
        missile3.transform.position = transform.position + new Vector3(-7f,2.5f,0);
        missile3.GetComponent<NatureMissile>().SetDirection(Vector3.up + Vector3.left);
        missile3.GetComponent<NatureMissile>().GetPosition(PlayerW.instance.transform.position + new Vector3(-2f,0,0),transform.position);

    }

    void ShootType2(){

        GameObject tornado = EnemyTornadoPool.instance.requestTornado();
        tornado.transform.position = PlayerW.instance.transform.position + new Vector3(0,-1f,0);

    }

    void ShootUltimate(Vector3 direction){


        GameObject bullet = Bullet3Pool.instance.requestBullet3();
        bullet.transform.position = transform.position + new Vector3(-7f,4f,0);
        bullet.GetComponent<UltimateAttack>().SetDirection(Vector3.left + Vector3.down + direction);


        

    }

    public void Hit(float damage){

        damage -= StatsEnemyBoss.instance.DEF;

        if(damage <= 0){
            damage = 1f;
        }

        StatsEnemyBoss.instance.HP -= damage;

        //Animation and effects
        animator.SetBool("TakeDamage",true);

        // text damage
        GameObject textGo = TextDamagePool.instance.requesText();
        textGo.transform.position = transform.position + new Vector3(-5.5f,6.5f,0);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);
        

        // effect damage 
        GameObject effectTextDamage =  effectPoolDamage.instance.requestBullet();
        effectTextDamage.transform.position = transform.position + new Vector3(-5f,5f,0);

        if(StatsEnemyBoss.instance.HP <= 0){

            //CloseDoor.instance.activeBlock = false;
            GameObject.FindGameObjectWithTag("EnemyBoss1").SetActive(false);

            gameObject.SetActive(false);
            

            GameObject effectEdeath = EffectDeathPool.instance.requestBulletBoss();
            effectEdeath.transform.position = transform.position;
            effectEdeath.transform.localScale = new Vector3(5f,5f,5f);

            PlayerW.instance.CountEnemyDefeat += 1;
        }

    }

    public void DesactivateTakeDamage(){
        animator.SetBool("TakeDamage",false);
    }



}

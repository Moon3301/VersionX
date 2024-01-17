using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyNature : MonoBehaviour
{
    public static BulletEnemyNature instance;
    public float Speed;
    private Vector3 Direction;
    public float damage;
    private Rigidbody2D Rigidbody2D;

    private float lanzadorX;

    private Vector3 Lanzador;

    private Vector3 Target;

    public float timeActive = 5f;

    private float targetX;
    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {

        if(gameObject.tag == "bulletEnemyNature"){

            lanzadorX = Lanzador.x;
            targetX = Target.x;

            float distancia = targetX - lanzadorX;
            float nextX = Mathf.MoveTowards(transform.position.x, targetX, Speed * Time.deltaTime);
            float baseY = Mathf.Lerp(Lanzador.y, Target.y, (nextX - lanzadorX) / distancia);
            float height = 2f*(nextX - lanzadorX) * (nextX - targetX) / (-0.4f * distancia * distancia * distancia );

            Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);

            
            transform.position = movePosition;

            if(transform.position == Target){
                DestroyBullet();
            }

            UsefulLife();

        }

        
        
    }

    public static Quaternion LookAtTarget(Vector2 rotation){
        return Quaternion.Euler(0,0,Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

    public void GetPosition(Vector3 position, Vector3 positionL){
       Target = position;
       Lanzador = positionL;
       
    }

    public void GetDamage(float dam){
        damage = dam;
    }

    void UsefulLife(){

        timeActive -= Time.deltaTime;

        if(timeActive < 0){
            DestroyBullet();
            timeActive = 5f;
        }
    }
    
    
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
        
    }
    
    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        gameObject.SetActive(false);
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        GameObject explosion = ExplosionBulletPool.instance.requestExplosion();
        explosion.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.tag == "Player")
        {
            if(PlayerW.instance.gameObject.activeSelf == true){
                other.GetComponent<PlayerW>().Hit(damage);
                DestroyBullet();
            }
            
        }

        if(other.tag == "Block")
        {
            
            DestroyBullet();
        }

        if(other.tag == "shield")
        {
            DestroyBullet();
        }

        if(other.tag == "EnemyNature" && gameObject.tag == "AttackSword"){
            
            other.GetComponent<EnemyNature>().Hit(damage);
            DestroyBullet();
        }

        if(other.tag == "EnemySlime" && gameObject.tag == "AttackSword"){
            
            other.GetComponent<EnemySlime>().Hit(damage);
            DestroyBullet();

        }

    }
}

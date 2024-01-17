using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    public static MagicAttack instance;
    public float Speed;
    private Vector3 Direction;

    public float damage;
    private Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
        
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

        GameObject explosion = EffectExplosionBulletPool.instance.requestBullet();
        explosion.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other){

        damage = Stats.instance.ATK;

        if(other.tag == "EnemyNature"){
            other.GetComponent<EnemyNature>().Hit(damage);
            DestroyBullet();
        }

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyMecha>().Hit(damage);
            DestroyBullet();
        }

        if(other.tag == "EnemySlime"){
            other.GetComponent<EnemySlime>().Hit(damage);
            DestroyBullet();
        }

        if(other.tag == "Block")
        {
            DestroyBullet();
        }

        if(other.tag == "ShieldSlime"){
            DestroyBullet();
        }

        if(other.tag == "ShieldSuccubus"){
            DestroyBullet();
        }

        if(other.tag == "Succubus"){
            other.GetComponent<SuccubusSummonerSlime>().Hit(damage);
            DestroyBullet();
        }

        if(other.tag == "EnemyBoss"){
            other.GetComponent<EnemyBoss1>().Hit(damage);
            DestroyBullet();
        }

    }
    
}

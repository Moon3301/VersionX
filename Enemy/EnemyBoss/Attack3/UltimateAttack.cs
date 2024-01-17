using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAttack : MonoBehaviour
{
    public static UltimateAttack instance;
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

        GameObject explosion = EffectExplosion3Pool.instance.requestExplosion3();
        explosion.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerW>().Hit(damage);
            DestroyBullet();
        }

        if(other.tag == "Block")
        {
            
            DestroyBullet();
        }


        
    }

    
}

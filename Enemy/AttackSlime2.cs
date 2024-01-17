using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlime2 : MonoBehaviour
{
    public static AttackSlime2 instance;
    public float Speed;
    private Vector3 Direction;

    public float damage;

    public GameObject destroyEffect;

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
        Destroy(gameObject);
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other){

        PlayerW player = other.GetComponent<PlayerW>();

        if(player != null){

            player.Hit(damage);
            DestroyBullet();
            
        }

        if(other.tag == "Block"){
            DestroyBullet();
        }
    }

}

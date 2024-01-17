using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public static Weapon1 instance;
    public float Speed;
    private Vector3 Direction;
    public GameObject destroyEffect;
    private Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update

     private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
    }

    private void OnTriggerEnter2D(Collider2D collision){

        PlayerW player = collision.GetComponent<PlayerW>();

        if(player != null){
            
            player.Hit(1);
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        if(collision.tag == "Block"){
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }


    }
}

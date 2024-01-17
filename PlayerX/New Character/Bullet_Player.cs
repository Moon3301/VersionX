using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed;
    private Vector3 Direction;
    public GameObject destroyEffect;
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Enemy"){

            


        }


    }
}

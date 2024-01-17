using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2 : MonoBehaviour
{

    public GameObject bullet;
    private float LastShoot;
    public float distancex;
    public GameObject player;
    public GameObject destroyEffect;
    public Rigidbody2D rb;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        distancex = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (distancex < 8f && Time.time > LastShoot + 1f)
        {

            Shoot();
            LastShoot = Time.time;
        }

        // apuntar canon al jugador


        Vector2 objetivo = new Vector2(player.transform.position.x, player.transform.position.y);

        transform.LookAt(objetivo);

        

        
        
    }

    void Shoot()
    {
        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
        
    }
}

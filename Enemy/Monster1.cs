using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{

    public Animator animator;
    public static Monster1 instance;
    public float HP;

    public GameObject DestroyEffect;

    public GameObject bullet;

    public float LastShoot;

    public GameObject player;

    public Rigidbody2D rigidbody2d;

    public float velocity;

    private Vector3 direction;

    private GameObject position;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null) return;

        direction = player.transform.position - transform.position;

        float distancex = Mathf.Abs(player.transform.position.x - transform.position.x); // Distancia(x) entre el enemigo y daniel

        
        if(direction.x >= 0.0f){
            transform.localScale = new Vector3(-1,1,1);
        }
        else{
            transform.localScale = new Vector3(1,1,1);
        }



        if (distancex < 4f)
        {

            Vector2 objetivo = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 nuevapos = Vector2.MoveTowards(rigidbody2d.position, objetivo, velocity * Time.deltaTime); 
            
            rigidbody2d.MovePosition(nuevapos);

            // agregar animacion de caminar
        }

        if (distancex < 7f && Time.time > LastShoot + 2f)
        {
            Shoot();
            animator.SetBool("Attack", true);
            LastShoot = Time.time;
        }
        else
        {
            return;
        }
        
    }

    void AttackFalse(){
        animator.SetBool("Attack", false);
    }

    void Shoot()
    {   
        Vector3 obj = new Vector3(player.transform.position.x, player.transform.position.y, 0);


        GameObject bulletClone = Instantiate(bullet, transform.position + new Vector3(-2.5f,2f,0), Quaternion.identity);
        bulletClone.GetComponent<Weapon1>().SetDirection(PlayerW.instance.transform.position - transform.position + new Vector3(0,-1f,0));

        GameObject bulletClone1 = Instantiate(bullet, transform.position + new Vector3(-2.5f,2f,0), Quaternion.identity);
        bulletClone1.GetComponent<Weapon1>().SetDirection(PlayerW.instance.transform.position - transform.position + new Vector3(0,-1f,0));

        GameObject bulletClone2 = Instantiate(bullet, transform.position + new Vector3(-2.5f,2f,0), Quaternion.identity);
        bulletClone2.GetComponent<Weapon1>().SetDirection(PlayerW.instance.transform.position - transform.position + new Vector3(0,-1f,0));

    }

    void HitFalse()
    {
        animator.SetBool("TakeHit", false);
    }

    public void Hit(){

        animator.SetBool("TakeHit", true);

        HP -= 1;
        if (HP <= 0)
        {
            Destroy(gameObject);
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);

        }
    }

    
}

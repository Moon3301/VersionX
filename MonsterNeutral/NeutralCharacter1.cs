using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralCharacter1 : MonoBehaviour
{
    // Start is called before the first frame update


    public static NeutralCharacter1 instance;

    public GameObject objetivo;

    public Rigidbody2D rb;
    private bool Grounded;
    public Animator animator;

    public float Health;

    private float LastShoot;

    public float velocity;

    public float distancex;

    public GameObject destroyEffect;

    private Vector3 Direction;

    public GameObject textDamage;

    private void Awake(){
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        distancex = Mathf.Abs(objetivo.transform.position.x - transform.position.x);

        Direction = objetivo.transform.position - transform.position;

        if(Direction.x > 0){
            transform.localScale = new Vector3(1,1,1);
        }
        else{
            transform.localScale = new Vector3(-1,1,1);
        }

        if(distancex <10f && distancex > 2f){

            Vector2 obj = new Vector2(objetivo.transform.position.x, objetivo.transform.position.y);
            Vector2 nuevapos = Vector2.MoveTowards(rb.position, obj  , velocity * Time.deltaTime); 
            rb.MovePosition(nuevapos);
        }

        if(distancex < 3f && Time.time > LastShoot + 2f){


            Shoot();

            LastShoot = Time.time;
           
        }
        
    }

    public void Shoot(){


    }

    public void Hit(float damage){




    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyWizard : MonoBehaviour
{
    public float WizardType;
    public GameObject player;

    // Instanciar personaje
    public static EnemyWizard instance;

    // weapon
    public GameObject bullet;
    
    //fisicas
    public Rigidbody2D rb;
    public Transform position;

    public Animator animator;

    // Stats
    public float Health;

    private float LastShoot;

    public float velocity;

    public float distancex;

    public GameObject destroyEffect;

    private float time = 1f;

    // text damage

    public GameObject textDamage;
    // Start is called before the first frame update

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        distancex = Mathf.Abs(player.transform.position.x - transform.position.x);

        Vector3 direction = player.transform.position - position.transform.position;
   

        if (direction.x > 0f){
            position.transform.localScale = new Vector3(-1f, 1f, 1f);
        }  
        else {
            position.transform.localScale = new Vector3(1f, 1f, 1f);
        }


        if (distancex < 10f && Time.time > LastShoot + 2f){
            animator.SetBool("attack", true);
                
            Shoot();
                
            LastShoot = Time.time;
        }

        
    }

    public void Shoot(){

        Vector3 direction;
        if(transform.localScale.x == -1f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bulletInstance = WizardBulletPooling.instance.requestBullet();

        bulletInstance.transform.position = transform.position ;
        bulletInstance.GetComponent<BulletEnemyNature>().SetDirection(direction);
        bulletInstance.GetComponent<BulletEnemyNature>().GetPosition(PlayerW.instance.transform.position, transform.position+ new Vector3(0,1.5f,0));
    }

    public void Hit(float damage){

        Health = Health - damage;

        GameObject textGo = TextDamagePool.instance.requesText();
        textGo.transform.position = transform.position + new Vector3(0,0.5f,0);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);

        if(Health <= 0){
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

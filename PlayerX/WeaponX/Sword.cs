using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    public static Sword instance;
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
      
    }

    
    /*
    private void OnTriggerEnter2D(Collider2D other){

        Monster1 monster = other.GetComponent<Monster1>();
        Slime slime = other.GetComponent<Slime>();
        Slime2 slime2 = other.GetComponent<Slime2>();

        

        if(slime != null){
            slime.Hit(damage);
            animAttack();
        }

        if(monster != null){
            animAttack();
            monster.Hit();

        }

        if(other.tag == "Enemy"){
            animAttack();
            other.GetComponent<EnemyMecha>().Hit(damage);

        }

        if(other.tag == "Enemy2"){
            animAttack();
            other.GetComponent<EnemyNature>().Hit(damage);

        }

        if(other.tag == "enemyWizard"){
            animAttack();
            other.GetComponent<EnemyWizard>().Hit(damage);

        }

        if(other.tag == "EnemySlime"){

            other.GetComponent<EnemySlime>().Hit(damage);
        }

        if(other.tag == "ShieldSlime"){
            
            Instantiate(ShieldSlime.instance.effectShield, transform.position, Quaternion.identity);

            PlayerW.instance.StartForceRevert();

        }
        

    }
    */




}

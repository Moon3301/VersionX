using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAttackBoom : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "EnemySlime"){
            
            other.GetComponent<EnemySlime>().Hit(damage);

        }

        if(other.tag == "EnemyNature"){
            other.GetComponent<EnemyNature>().Hit(damage);
        }

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyMecha>().Hit(damage);
            
        }

        if(other.tag == "Succubus"){
            other.GetComponent<SuccubusSummonerSlime>().Hit(damage);
            
        }

        if(other.tag == "EnemyBoss"){
            other.GetComponent<EnemyBoss1>().Hit(damage);
        }

    }
}

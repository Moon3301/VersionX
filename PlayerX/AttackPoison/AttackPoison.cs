using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoison : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "EnemySlime"){

            other.GetComponent<EnemySlime>().Hit(0.5f);
            other.GetComponent<EnemySlime>().StartForceRepulse();
        }




    }

    private void OnTriggerStay2D(Collider2D other){

        if(other.tag == "EnemySlime"){

            other.GetComponent<EnemySlime>().Hit(Time.deltaTime);
            other.GetComponent<EnemySlime>().StartForceRepulse();
        }

    }



}

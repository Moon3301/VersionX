using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticle : MonoBehaviour
{

    public float damage;

    void Start() {
        
        

    }
    private void OnTriggerStay2D(Collider2D other){

        if(other.tag == "EnemySlime"){

            other.GetComponent<EnemySlime>().Hit(damage);
            gameObject.SetActive(false);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDamageBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;

    void Update(){
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){
            
            if(Shield.instance.gameObject.activeSelf == false){
                other.GetComponent<PlayerW>().Hit(damage);
            }
            
            
            
        }



    }
}

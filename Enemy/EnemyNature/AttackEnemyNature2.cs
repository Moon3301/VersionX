using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyNature2 : MonoBehaviour
{
    // Start is called before the first frame update

    private float damage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(float dam){
        damage = dam;
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){
            
            other.GetComponent<PlayerW>().Hit(damage);
            
            
        }
    }
}

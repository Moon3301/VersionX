using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlime : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;
    void Start()
    {
        damage = gameObject.GetComponentInParent<StatsEnemy>().ATK;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){

        PlayerW player = other.gameObject.GetComponent<PlayerW>();

        if(other.gameObject.tag == "Player"){

            if(PlayerW.instance.gameObject.activeSelf == true){
                player.Hit(damage);
            }
            


        }

    }
}

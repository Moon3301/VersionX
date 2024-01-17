using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlime1 : MonoBehaviour
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

        PlayerW player = other.GetComponent<PlayerW>();

        if(player != null){
            player.Hit(damage);
        }



    }
}

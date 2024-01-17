using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSlime : MonoBehaviour
{
    // Start is called before the first frame update
    public static ShieldSlime instance;
    public GameObject effectShield;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){

        PlayerW player = other.gameObject.GetComponent<PlayerW>();

        if(other.gameObject.tag == "Player"){

            Instantiate(effectShield, transform.position, Quaternion.identity);


        }



    }
}

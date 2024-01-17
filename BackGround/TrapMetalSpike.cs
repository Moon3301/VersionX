using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMetalSpike : MonoBehaviour
{

    public static TrapMetalSpike instance;
    public float damage;

    void Start()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Player"){
            other.GetComponent<PlayerW>().Hit(damage);
        }

    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldOnWalk : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {

        

        if(other.tag == "Player"){
            PlayerW.instance.HoldOnWalkOn();
            
            
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.tag == "Player"){
            PlayerW.instance.HoldOnWalkOn();
            
        }

       
        
        
    }

    private void OnTriggerExit2D(Collider2D other) {

        if(other.tag == "Player"){
            PlayerW.instance.HoldOnWalkOff();
            
        }
    }

}

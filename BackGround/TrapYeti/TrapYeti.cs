using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapYeti : MonoBehaviour
{

    public static TrapYeti instance;

    void Awake(){
        instance = this;
    }

    public Animator animator;
    public Animator animWood;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){

           animator.SetBool("active", true);
        }


        


    }

    public void DesactivateAnim(){
        animator.SetBool("active", false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(animator.GetBool("active") == true){
            

        }
        
    }
}

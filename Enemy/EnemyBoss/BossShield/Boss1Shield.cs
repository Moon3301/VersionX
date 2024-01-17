using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Shield : MonoBehaviour
{
    // Start is called before the first frame update
    public static Boss1Shield instance;
    public GameObject effectShield;
    public float countDesactivateShield = 0;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countDesactivateShield >= 3){
            gameObject.SetActive(false);
            Debug.Log("Escudo desctruido");
            countDesactivateShield = 0;
            
            
        }

        
       
    }

    private void OnDisable() {
        countDesactivateShield = 0;
    }

    void SymbolExclamation(){

        GameObject exclamation = SymbolsPool.instance.requestExclamation();
        exclamation.transform.position = transform.position + new Vector3(0,4f,0);
        exclamation.transform.localScale = new Vector3(2f,2f,2f);

    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "Player"){
            
            other.gameObject.GetComponent<PlayerW>().StartForceRevert();
            Instantiate(effectShield,transform.position,Quaternion.identity);
           
        }


    }
    
    private void OnTriggerEnter2D(Collider2D other){


        if(other.tag == "AttackTornado"){
            
            countDesactivateShield += 1;
            Instantiate(effectShield,transform.position + new Vector3(0,3f,0),Quaternion.identity);

            //Question
            if(countDesactivateShield <=2){
                GameObject question = SymbolsPool.instance.requestQuestion();
                question.transform.position = transform.position + new Vector3(0,4f,0);
                question.transform.localScale = new Vector3(2f,2f,2f);
            }else if(countDesactivateShield == 3){
                SymbolExclamation();
            }
            

            //Exclamation





        }

        if(other.gameObject.tag == "Player"){
            
            other.gameObject.GetComponent<PlayerW>().StartForceRevert();
            Instantiate(effectShield,transform.position,Quaternion.identity);
           
        }

    }

    

}

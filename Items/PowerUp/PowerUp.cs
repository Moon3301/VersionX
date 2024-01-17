using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update

    public static PowerUp instance;
    public float typePowerUp;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyPowerUp(){

        GameObject destroyPowerUp = DestroyEffectPickUpPool.instance.requestBullet();
        destroyPowerUp.transform.position = transform.position;

        gameObject.SetActive(false);

    }
    
    private void OnTriggerEnter2D(Collider2D other){


        if(other.tag == "Player"){

            if(typePowerUp == 1){
            
                // Health 
                other.GetComponent<Stats>().CURRENTHP += 10f;
                DestroyPowerUp();
                
            }

            if(typePowerUp == 2){

                // Bullet
                if(SkillController.instance.buttonBullet.activeSelf == false){
                    SkillController.instance.ActiveButtonBullet();
                    SkillController.instance.DesactiveButtonShield();
                    DestroyPowerUp();
                }else{
                    Debug.Log("Habilidad ya esta activa");
                }
                
                
            }

            if(typePowerUp == 3){

                // Shield
                if(SkillController.instance.buttonShield.activeSelf == false){
                    SkillController.instance.DesactiveButtonBullet();
                    SkillController.instance.ActiveButtonShield();
                    DestroyPowerUp();
                }else{
                    Debug.Log("Habilidad ya esta activa");
                }
                
                
            }

        }

    }
}

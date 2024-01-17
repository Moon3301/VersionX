using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    // PK_COMPLETEV1
    public static PlayerController instance;
    public GameObject EffectSoul;
    public GameObject Player;

    public bool activeEffect = false;

    public GameObject activePlayer;
    
    void Start()
    {
        EffectSoul.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(Player.activeSelf == true){
            activePlayer = Player;
        }
        
        if (EffectSoul.activeSelf == true){
            activePlayer = EffectSoul;
        }


        if(activeEffect == false){
            if(Input.GetKeyDown(KeyCode.H)){

                ActiveEffectSoul();
            
            }
        }

        if(activeEffect == true){

            if(Input.GetKeyDown(KeyCode.J)){
                DesactiveEffectSoul();

            }
        }
       

        // Effect Soul
        /*
        if(activeEffect == true){
            if(Input.GetKeyDown(KeyCode.H)){
                
                Player.SetActive(true);
                Player.transform.position = EffectSoul.transform.position;
                EffectSoul.SetActive(false);
                activeEffect = false;
            }
        }
        */
    }

    public void ActiveEffectSoul(){

        if(Stats.instance.CURRENTMP > 0){

            activeEffect = true;
            EffectSoul.SetActive(true);
            EffectSoul.transform.position = Player.transform.position;
            Player.SetActive(false);
        }

    }

    public void DesactiveEffectSoul(){

        activeEffect = false;
        EffectSoul.SetActive(false);
        Player.transform.position = EffectSoul.transform.position;
        Player.SetActive(true);
        
    }



    public void Hit(float damage){

        // Efecto ralentizar al recibir un ataque enemigo
        int random = Random.Range(1,10);

        if(random <= 3){
            CameraScripts.instance.TimeSlow(0.05f);
        }
        
        // calculo de dano recibido (DMG - DEF)
        damage = damage - Stats.instance.DEF;

        if(damage < 0){
            damage = 1;
        }
        
        Stats.instance.CURRENTHP -= damage;

        PlayerW.instance.Hit(damage);
        

    }

}

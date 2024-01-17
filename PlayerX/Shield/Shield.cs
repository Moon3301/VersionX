using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public static Shield instance;

    public GameObject effectShield;

    public bool EffectSparring = false;

    void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "EnemySlime"){

            EffectActiveShield(other.gameObject.transform);
            other.GetComponent<EnemySlime>().StartForceRepulse();

            EffectSlownDownShield(0.5f);
            
        }

        if(other.tag == "AttackTornado"){
            
            EffectActiveShield(other.gameObject.transform);

            EffectSlownDownShield(0.5f);
        }
        
        if(other.tag == "bulletEnemy"){

            EffectActiveShield(other.gameObject.transform);
            EffectSlownDownShield(0.5f);
            if(EffectSparring == true){

                EffectSparringActive(other.gameObject);

            }else{
                other.gameObject.SetActive(false);
            }
            
        }

        if(other.tag == "bulletEnemyNature"){

            EffectActiveShield(other.gameObject.transform);
            EffectSlownDownShield(0.5f);

            if(EffectSparring == true){

                EffectSparringActive(other.gameObject);

            }else{
                other.gameObject.SetActive(false);
            }

        }
      
    }

    public void EffectSlownDownShield(float time){

        if(PlayerW.instance.TimeActiveShield < time){

            EffectSparring = true;
        }

    }

    public void EffectActiveShield(Transform val){
        GameObject effect = EffectShieldPool.instance.requestEffectShield();
        effect.transform.position = val.position;
    }


    public void EffectSparringActive(GameObject bullet){

        Vector3 obj;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = bullet.transform.position.x - player.transform.position.x;

        if(distance >0){
            obj = Vector3.right;
        }else{
            obj = Vector3.left;
        }
        
        if(bullet.tag == "bulletEnemy"){
            bullet.GetComponent<EnemyBullet>().SetDirection(obj);
        }

        if(bullet.tag == "bulletEnemyNature"){
            bullet.GetComponent<BulletEnemyNature>().SetDirection(obj);
        }
        
        ParticleSystem.MainModule main = bullet.GetComponent<ParticleSystem>().main;
        main.startColor = new Color(0, 50, 255, 255);
        bullet.tag = "AttackSword";

        DesactiveSparring();
    }

    public void DesactiveSparring(){
        EffectSparring = false;
    }

}

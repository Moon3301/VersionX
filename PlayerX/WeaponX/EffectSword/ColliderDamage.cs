using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDamage : MonoBehaviour
{
    // Start is called before the first frame update

    void Update(){


    }

    void EffectImpact(Transform pos){

        GameObject effect = EffectExplosionBulletPool.instance.requestBullet();
        effect.transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "EnemySlime"){
            other.GetComponent<EnemySlime>().Hit(Stats.instance.ATK);
        }

        
        if(other.tag == "Succubus"){
            if(other.GetComponent<SuccubusSummonerSlime>().Shield.activeSelf == false){
                other.GetComponent<SuccubusSummonerSlime>().Hit(Stats.instance.ATK);
            }else{
                EffectImpact(other.GetComponent<SuccubusSummonerSlime>().transform);
            }
            
        }

        if(StageController.instance.enemyBoss != null){
            if(Boss1Shield.instance.gameObject.activeSelf == false ){
            
                if((other.tag == "EnemyBoss")){

                other.GetComponent<EnemyBoss1>().Hit(Stats.instance.ATK);
                }
            }
        }

        if(other.tag == "EnemyNature"){
            other.GetComponent<EnemyNature>().Hit(Stats.instance.ATK);
        }
        
        


    }
}

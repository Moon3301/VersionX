using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDiamond : MonoBehaviour
{
    public void EffectDestroyDiamond(){

        GameObject effect = EffectDestroyGoldPool.instance.requestBullet();
        effect.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){

            EffectDestroyDiamond();
            gameObject.SetActive(false);
            
        }
    

    }
}

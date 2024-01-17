using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGold : MonoBehaviour
{
    // Start is called before the first frame update
    public void EffectDestroyGold(){

        GameObject effect = EffectDestroyGoldPool.instance.requestBullet();
        effect.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){

            EffectDestroyGold();
            gameObject.SetActive(false);
            
        }
    

    }
}

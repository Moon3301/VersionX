using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public static PickUp instance;
    public bool recogido = false;
    public string typePickUp;

    void Awake()
    {
        instance = this;
    }
    public void EffectDestroyGold(){

        GameObject effectDestroyGold = EffectExplosionItemPool.instance.requestEffectDestroyGold();
        effectDestroyGold.transform.position = transform.position;
    }

    public void EffectDestroyDiamond(){

        GameObject effectDestroyDiamond = EffectExplosionItemPool.instance.requestEffectDestroyDiamond();
        effectDestroyDiamond.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){

            recogido = true;
            gameObject.SetActive(false);

            if(typePickUp == "Gold"){
                Inventario.instance.Gold += 1;
                EffectDestroyGold();
            }
            if(typePickUp == "Diamond"){
                Inventario.instance.Diamond += 1;
                EffectDestroyDiamond();
            }

            
        }
    

    }
}

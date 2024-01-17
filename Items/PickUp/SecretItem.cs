using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretItem : MonoBehaviour
{
    // Start is called before the first frame update
    public bool itemRecoleted;
    public float NumSecret;
    void Start()
    {
        itemRecoleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyEffect(){

        gameObject.SetActive(false);

        GameObject effectDestroyDiamond = EffectExplosionItemPool.instance.requestEffectDestroyDiamond();
        effectDestroyDiamond.transform.position = transform.position;



    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player"){
            
            if(NumSecret == 1){
                StageController.instance.secretItem1 = true;
                DestroyEffect();
            }
            
            if(NumSecret == 2){
                StageController.instance.secretItem2 = true;
                DestroyEffect();
            }

            

        }


    }
}

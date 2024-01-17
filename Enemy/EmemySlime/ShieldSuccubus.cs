using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSuccubus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EffectImpact(){

        GameObject effect = EffectExplosionBulletPool.instance.requestBullet();
        effect.transform.position = transform.position;


    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "AttackSword"){
            EffectImpact();
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.tag == "Missile"){
            EffectImpact();
        }

    }

    
}

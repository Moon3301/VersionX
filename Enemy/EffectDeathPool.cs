using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDeathPool : MonoBehaviour
{
    public static EffectDeathPool instance;
    
    [SerializeField] private GameObject effectDeath;

    [SerializeField] private GameObject effectDeathBoss;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private List<GameObject> effectDeathPool;

    [SerializeField] private List<GameObject> effectDeathBossPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddEffectDeathPool(poolSize);
       AddEffectDeathBossPool(poolSize);
        
    }

    private void AddEffectDeathPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(effectDeath);
            obj.SetActive(false);
            effectDeathPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestBullet(){

        for(int i = 0; i< effectDeathPool.Count; i++){
            if(!effectDeathPool[i].activeSelf){
                
                effectDeathPool[i].SetActive(true);
                return effectDeathPool[i];
            }
        }

        AddEffectDeathPool(1);
        return effectDeathPool[effectDeathPool.Count - 1];
    }

    // Deaht boss pool

    private void AddEffectDeathBossPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(effectDeathBoss);
            obj.SetActive(false);
            effectDeathBossPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestBulletBoss(){

        for(int i = 0; i< effectDeathBossPool.Count; i++){
            if(!effectDeathBossPool[i].activeSelf){
                
                effectDeathBossPool[i].SetActive(true);
                return effectDeathBossPool[i];
            }
        }

        AddEffectDeathBossPool(1);
        return effectDeathBossPool[effectDeathBossPool.Count - 1];
    }
}

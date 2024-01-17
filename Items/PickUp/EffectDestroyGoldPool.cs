using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroyGoldPool : MonoBehaviour
{
    public static EffectDestroyGoldPool instance;
    
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private int poolSize = 15;
    [SerializeField] private List<GameObject> goldPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddGoldToPool(poolSize);
        
    }

    private void AddGoldToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(destroyEffect);
            obj.SetActive(false);
            goldPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestBullet(){

        for(int i = 0; i< goldPool.Count; i++){
            if(!goldPool[i].activeSelf){
                
                goldPool[i].SetActive(true);
                return goldPool[i];
            }
        }

        AddGoldToPool(1);
        return goldPool[goldPool.Count - 1];
    }
}

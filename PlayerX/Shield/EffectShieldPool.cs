using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectShieldPool : MonoBehaviour
{
    public static EffectShieldPool instance;
    
    [SerializeField] private GameObject shield;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> shieldPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddShieldToPool(poolSize);
        
    }

    private void AddShieldToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(shield);
            obj.SetActive(false);
            shieldPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestEffectShield(){

        for(int i = 0; i< shieldPool.Count; i++){
            if(!shieldPool[i].activeSelf){
                
                shieldPool[i].SetActive(true);
                return shieldPool[i];
            }
        }

        AddShieldToPool(1);
        return shieldPool[shieldPool.Count - 1];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGoldPool : MonoBehaviour
{
    public static itemGoldPool instance;
    
    [SerializeField] private GameObject gold;
    [SerializeField] private int poolSize = 10;
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
            GameObject obj = Instantiate(gold);
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

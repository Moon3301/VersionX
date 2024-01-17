using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroyNatureMissile : MonoBehaviour
{
    public static EffectDestroyNatureMissile instance;
    
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> destroyEffectPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddEffectPool(poolSize);
        
    }

    private void AddEffectPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(destroyEffect);
            obj.SetActive(false);
            destroyEffectPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestEffectDestroy(){

        for(int i = 0; i< destroyEffectPool.Count; i++){
            if(!destroyEffectPool[i].activeSelf){
                
                destroyEffectPool[i].SetActive(true);
                return destroyEffectPool[i];
            }
        }

        AddEffectPool(1);
        return destroyEffectPool[destroyEffectPool.Count - 1];
    }
}

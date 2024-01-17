using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExplosionItemPool : MonoBehaviour
{
    public static EffectExplosionItemPool instance;
    
    [SerializeField] private GameObject destroyEffectGold;
    [SerializeField] private GameObject destroyEffectDiamond;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private List<GameObject> destroyEffectGoldPool;
    [SerializeField] private List<GameObject> destroyEffectDiamondPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddEffectGoldToPool(poolSize);
        
    }

    // Effect Destroy Gold
    private void AddEffectGoldToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(destroyEffectGold);
            obj.SetActive(false);
            destroyEffectGoldPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestEffectDestroyGold(){

        for(int i = 0; i< destroyEffectGoldPool.Count; i++){
            if(!destroyEffectGoldPool[i].activeSelf){
                
                destroyEffectGoldPool[i].SetActive(true);
                return destroyEffectGoldPool[i];
            }
        }

        AddEffectGoldToPool(1);
        return destroyEffectGoldPool[destroyEffectGoldPool.Count - 1];
    }

    // Effect destroy Diamond


    private void AddEffectDiamondToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(destroyEffectDiamond);
            obj.SetActive(false);
            destroyEffectDiamondPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestEffectDestroyDiamond(){

        for(int i = 0; i< destroyEffectDiamondPool.Count; i++){
            if(!destroyEffectDiamondPool[i].activeSelf){
                
                destroyEffectDiamondPool[i].SetActive(true);
                return destroyEffectDiamondPool[i];
            }
        }

        AddEffectDiamondToPool(1);
        return destroyEffectDiamondPool[destroyEffectDiamondPool.Count - 1];
    }


}

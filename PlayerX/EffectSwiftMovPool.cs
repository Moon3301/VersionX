using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwiftMovPool : MonoBehaviour
{
    public static EffectSwiftMovPool instance;
    
    [SerializeField] private GameObject Effect;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> EffectSwiftPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddEffectToPool(poolSize);
        
    }

    private void AddEffectToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(Effect);
            obj.SetActive(false);
            EffectSwiftPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestEffect(){

        for(int i = 0; i< EffectSwiftPool.Count; i++){
            if(!EffectSwiftPool[i].activeSelf){
                
                EffectSwiftPool[i].SetActive(true);
                return EffectSwiftPool[i];
            }
        }

        AddEffectToPool(1);
        return EffectSwiftPool[EffectSwiftPool.Count - 1];
    }
}

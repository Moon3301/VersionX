using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSowrdPool : MonoBehaviour
{
     public static EffectSowrdPool instance;
    
    [SerializeField] private GameObject effect1;
    [SerializeField] private GameObject effect2;
    [SerializeField] private GameObject effect3;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> effect1Pool;
    [SerializeField] private List<GameObject> effect2Pool;
    [SerializeField] private List<GameObject> effect3Pool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddGoldToPool(poolSize);
       AddGoldToPool2(poolSize);
       AddGoldToPool3(poolSize);
        
    }

    // effect 1
    private void AddGoldToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(effect1);
            obj.SetActive(false);
            effect1Pool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestEffectSword1(){

        for(int i = 0; i< effect1Pool.Count; i++){
            if(!effect1Pool[i].activeSelf){
                
                effect1Pool[i].SetActive(true);
                return effect1Pool[i];
            }
        }

        AddGoldToPool(1);
        return effect1Pool[effect1Pool.Count - 1];
    }

    //effect 2

    private void AddGoldToPool2(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(effect2);
            obj.SetActive(false);
            effect2Pool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestEffectSword2(){

        for(int i = 0; i< effect2Pool.Count; i++){
            if(!effect2Pool[i].activeSelf){
                
                effect2Pool[i].SetActive(true);
                return effect2Pool[i];
            }
        }

        AddGoldToPool2(1);
        return effect2Pool[effect2Pool.Count - 1];
    }

    // effect 3

    private void AddGoldToPool3(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(effect3);
            obj.SetActive(false);
            effect3Pool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestEffectSword3(){

        for(int i = 0; i< effect3Pool.Count; i++){
            if(!effect3Pool[i].activeSelf){
                
                effect3Pool[i].SetActive(true);
                return effect3Pool[i];
            }
        }

        AddGoldToPool2(1);
        return effect3Pool[effect3Pool.Count - 1];
    }

}

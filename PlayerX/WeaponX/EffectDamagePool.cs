using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamagePool : MonoBehaviour
{
    public static EffectDamagePool instance;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private int poolSize = 7;
    [SerializeField] private List<GameObject> bulletPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddBulletToPool(poolSize);
        
    }

    private void AddBulletToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            bulletPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestBullet(){

        for(int i = 0; i< bulletPool.Count; i++){
            if(!bulletPool[i].activeSelf){
                
                bulletPool[i].SetActive(true);
                return bulletPool[i];
            }
        }

        AddBulletToPool(1);
        return bulletPool[bulletPool.Count - 1];
    }
}

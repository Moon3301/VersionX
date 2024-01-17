using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3Pool : MonoBehaviour
{
    public static Bullet3Pool instance;
    
    [SerializeField] private GameObject bullet3
    ;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> BulletPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddBullet3ToPool(poolSize);
        
    }

    private void AddBullet3ToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(bullet3);
            obj.SetActive(false);
            BulletPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestBullet3(){

        for(int i = 0; i< BulletPool.Count; i++){
            if(!BulletPool[i].activeSelf){
                
                BulletPool[i].SetActive(true);
                return BulletPool[i];
            }
        }

        AddBullet3ToPool(1);
        return BulletPool[BulletPool.Count - 1];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public static BulletPoolingEnemy instance;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private int poolSize = 15;
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
                bulletPool[i].tag = "bulletEnemy";
                ParticleSystem.MainModule main = bulletPool[i].GetComponent<ParticleSystem>().main;
                main.startColor = new Color(29, 255, 0, 255);
                
                return bulletPool[i];
            }
        }

        AddBulletToPool(1);
        return bulletPool[bulletPool.Count - 1];
    }
}

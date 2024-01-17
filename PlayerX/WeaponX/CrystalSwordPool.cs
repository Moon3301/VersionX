using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSwordPool : MonoBehaviour
{
    // Start is called before the first frame update

    public static CrystalSwordPool instance;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private int poolSize = 15;
    [SerializeField] private List<GameObject> bulletPool;

    // 

    [SerializeField] private GameObject bullet2;

    [SerializeField] private List<GameObject> bulletPool2;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddBulletToPool(poolSize);
       AddBulletToPool2(poolSize);
        
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

    //

    private void AddBulletToPool2(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(bullet2);
            obj.SetActive(false);
            bulletPool2.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestBullet2(){

        for(int i = 0; i< bulletPool2.Count; i++){
            if(!bulletPool2[i].activeSelf){
                
                bulletPool2[i].SetActive(true);
                return bulletPool2[i];
            }
        }

        AddBulletToPool2(1);
        return bulletPool2[bulletPool2.Count - 1];
    }


}

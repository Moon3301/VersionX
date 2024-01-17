using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBulletPool : MonoBehaviour
{
    // Start is called before the first frame update
    public static ExplosionBulletPool instance;
    
    [SerializeField] private GameObject explosion;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> explosionPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddExplosionToPool(poolSize);
        
    }

    private void AddExplosionToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(explosion);
            obj.SetActive(false);
            explosionPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestExplosion(){

        for(int i = 0; i< explosionPool.Count; i++){
            if(!explosionPool[i].activeSelf){
                
                explosionPool[i].SetActive(true);
                return explosionPool[i];
            }
        }

        AddExplosionToPool(1);
        return explosionPool[explosionPool.Count - 1];
    }
}

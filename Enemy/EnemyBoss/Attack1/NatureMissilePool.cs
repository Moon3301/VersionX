using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureMissilePool : MonoBehaviour
{
    public static NatureMissilePool instance;
    
    [SerializeField] private GameObject missile;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> missilePool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddMissilePool(poolSize);
        
    }

    private void AddMissilePool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(missile);
            obj.SetActive(false);
            missilePool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestMissile(){

        for(int i = 0; i< missilePool.Count; i++){
            if(!missilePool[i].activeSelf){
                
                missilePool[i].SetActive(true);
                return missilePool[i];
            }
        }

        AddMissilePool(1);
        return missilePool[missilePool.Count - 1];
    }
}

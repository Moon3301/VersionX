using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTornadoPool : MonoBehaviour
{
    public static EnemyTornadoPool instance;
    
    [SerializeField] private GameObject tornado;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> tornadoPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddTornadoToPool(poolSize);
        
    }

    private void AddTornadoToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(tornado);
            obj.SetActive(false);
            tornadoPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestTornado(){

        for(int i = 0; i< tornadoPool.Count; i++){
            if(!tornadoPool[i].activeSelf){
                
                tornadoPool[i].SetActive(true);
                return tornadoPool[i];
            }
        }

        AddTornadoToPool(1);
        return tornadoPool[tornadoPool.Count - 1];
    }
}

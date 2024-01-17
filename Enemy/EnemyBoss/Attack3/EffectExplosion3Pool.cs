using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExplosion3Pool : MonoBehaviour
{
    public static EffectExplosion3Pool instance;
    
    [SerializeField] private GameObject Explosion3
    ;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> Explosion3Pool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddExplosion3ToBullet(poolSize);
        
    }

    private void AddExplosion3ToBullet(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(Explosion3
            );
            obj.SetActive(false);
            Explosion3Pool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requestExplosion3(){

        for(int i = 0; i< Explosion3Pool.Count; i++){
            if(!Explosion3Pool[i].activeSelf){
                
                Explosion3Pool[i].SetActive(true);
                return Explosion3Pool[i];
            }
        }

        AddExplosion3ToBullet(1);
        return Explosion3Pool[Explosion3Pool.Count - 1];
    }
}

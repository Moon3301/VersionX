using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDamagePool : MonoBehaviour
{
    public static TextDamagePool instance;
    
    [SerializeField] private GameObject text;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> textPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddTextToPool(poolSize);
        
    }

    private void AddTextToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(text);
            obj.SetActive(false);
            textPool.Add(obj);
            obj.transform.parent = transform;
        }

    }

    public GameObject requesText(){

        for(int i = 0; i< textPool.Count; i++){
            if(!textPool[i].activeSelf){
                
                textPool[i].SetActive(true);
                return textPool[i];
            }
        }

        AddTextToPool(1);
        return textPool[textPool.Count - 1];
    }
}

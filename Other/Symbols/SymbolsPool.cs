using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolsPool : MonoBehaviour
{
    public static SymbolsPool instance;
    
    [SerializeField] private GameObject Exclamation;
    [SerializeField] private GameObject Question;
    [SerializeField] private GameObject Proyectil;
    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject Heart;
    [SerializeField] private GameObject Skull;


    [SerializeField] private int poolSize = 5;
    [SerializeField] private List<GameObject> ExclamationPool;
    [SerializeField] private List<GameObject> QuestionPool;
    [SerializeField] private List<GameObject> ProyectilPool;
    [SerializeField] private List<GameObject> ShieldPool;
    [SerializeField] private List<GameObject> HeartPool;
    [SerializeField] private List<GameObject> SkullPool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

       AddExclamationToPool(poolSize);
        
    }

    // Exclamation
    private void AddExclamationToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(Exclamation);
            obj.SetActive(false);
            ExclamationPool.Add(obj);
            obj.transform.parent = transform;
        }

    }
    public GameObject requestExclamation(){

        for(int i = 0; i< ExclamationPool.Count; i++){
            if(!ExclamationPool[i].activeSelf){
                
                ExclamationPool[i].SetActive(true);
                ExclamationPool[i].transform.localScale = new Vector3(1f,1f,1f);
                return ExclamationPool[i];
            }
        }

        AddExclamationToPool(1);
        return ExclamationPool[ExclamationPool.Count - 1];
    }

    // Question 

    private void AddQuestionToPool(int amount){

        for(int i = 0; i< amount; i++){
            GameObject obj = Instantiate(Question);
            obj.SetActive(false);
            QuestionPool.Add(obj);
            obj.transform.parent = transform;
        }

    }
    public GameObject requestQuestion(){

        for(int i = 0; i< QuestionPool.Count; i++){
            if(!QuestionPool[i].activeSelf){
                
                QuestionPool[i].SetActive(true);
                QuestionPool[i].transform.localScale = new Vector3(1f,1f,1f);
                return QuestionPool[i];
            }
        }

        AddQuestionToPool(1);
        return QuestionPool[QuestionPool.Count - 1];
    }

    //
}

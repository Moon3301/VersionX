using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortalPool : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyPortalPool instance;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;

    [SerializeField] private List<GameObject> EnemyPoolAttack;

    [SerializeField] private List<GameObject> EnemyPoolDefend;

    [SerializeField] private List<GameObject> EnemyPoolWizard;

    [SerializeField] public int Poolsize;

    public GameObject player;

    private float distance;

    private float time = 1f;

    public float LevelPortal;

    public float countEnemy;

    

    void Awake()
    {
        instance = this;
    }

    private void AddEnemyAttackToPool(int Poolsize){

        for(int i = 0; i< Poolsize; i++){
            //enemy 1
            GameObject ene1 = Instantiate(enemy1);
            ene1.SetActive(false);
            EnemyPoolAttack.Add(ene1);
            ene1.transform.parent = transform;

        }

    }

    private void AddEnemyDefendToPool(int Poolsize){
        for(int i = 0; i< Poolsize; i++){
            GameObject ene2 = Instantiate(enemy2);
            ene2.SetActive(false);
            EnemyPoolDefend.Add(ene2);
            ene2.transform.parent = transform;
        }
    }

    private void AddEnemyWizardToPool(int Poolsize){

        for(int i = 0; i< Poolsize; i++){
            GameObject ene3 = Instantiate(enemy3);
            ene3.SetActive(false);
            EnemyPoolWizard.Add(ene3);
            ene3.transform.parent = transform;
        }
        

    }

    //request
    public GameObject requestEnemyAttack(){

        for(int i = 0; i< EnemyPoolAttack.Count; i++){
            if(!EnemyPoolAttack[i].activeSelf){
                
                EnemyPoolAttack[i].SetActive(true);
                //EnemyPoolAttack[i].GetComponent<StatsEnemy>().CalculateLVL();
                countEnemy +=1;
                return EnemyPoolAttack[i];
            }
        }

        //AddEnemyAttackToPool(1);
        //return EnemyPoolAttack[EnemyPoolAttack.Count - 1];
        return null;
    }

    public GameObject requestEnemyDefend(){

        for(int i = 0; i< EnemyPoolDefend.Count; i++){
            if(!EnemyPoolDefend[i].activeSelf){
                
                EnemyPoolDefend[i].SetActive(true);
                //EnemyPoolDefend[i].GetComponent<StatsEnemy>().CalculateLVL();
                countEnemy +=1;
                return EnemyPoolDefend[i];
            }
        }

        //AddEnemyDefendToPool(1);
        //return EnemyPoolDefend[EnemyPoolDefend.Count - 1];
        return null;
    }

    public GameObject requestEnemyWizard(){

        for(int i = 0; i< EnemyPoolWizard.Count; i++){
            if(!EnemyPoolWizard[i].activeSelf){
                
                EnemyPoolWizard[i].SetActive(true);
                //EnemyPoolWizard[i].GetComponent<StatsEnemy>().CalculateLVL();
                countEnemy +=1;
                return EnemyPoolWizard[i];
            }
        }

        //AddEnemyWizardToPool(1);
        //return EnemyPoolWizard[EnemyPoolWizard.Count - 1];
        return null;
    }




    void Start()
    {
        AddEnemyAttackToPool(Poolsize);
        AddEnemyDefendToPool(Poolsize);
        AddEnemyWizardToPool(Poolsize);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if(distance < 10){

            InvocarEnemigoAttack();
            InvocarEnemigoDefend();
            InvocarEnemigoWizard();

        }

        if(countEnemy >= 12){
            gameObject.SetActive(false);
            countEnemy = 0;
        }
        
    }


    void InvocarEnemigoAttack(){

        time -= Time.deltaTime;
        if(time< 0){
                
            if(validarEnemigoActivo(EnemyPoolAttack) == false){
                GameObject enemyAttack = requestEnemyAttack();
                enemyAttack.transform.position = transform.position;
                enemyAttack.GetComponent<EnemySlime>().player = player;
                enemyAttack.GetComponent<StatsEnemy>().LVL = LevelPortal;
                
                enemyAttack.GetComponent<Transform>().parent = EnemyPool.instance.transform;
               

                time = 1f;

            }
                
        }
            
    }

    void InvocarEnemigoDefend(){

        time -= Time.deltaTime;
        if(time< 0){
                
            if(validarEnemigoActivo(EnemyPoolDefend) == false){
                GameObject enemyDefend = requestEnemyDefend();
                enemyDefend.transform.position = transform.position;
                enemyDefend.GetComponent<EnemySlime>().player = player;
                enemyDefend.GetComponent<StatsEnemy>().LVL = LevelPortal;
                
                enemyDefend.GetComponent<Transform>().parent = EnemyPool.instance.transform;
                time = 1f;

            }
                
        }
            
        
    }

    void InvocarEnemigoWizard(){

        time -= Time.deltaTime;
        if(time< 0){
                
            if(validarEnemigoActivo(EnemyPoolWizard) == false){
                GameObject enemyWizard = requestEnemyWizard();
                enemyWizard.transform.position = transform.position;
                enemyWizard.GetComponent<EnemySlime>().player = player;
                enemyWizard.GetComponent<StatsEnemy>().LVL = LevelPortal;
                
                enemyWizard.GetComponent<Transform>().parent = EnemyPool.instance.transform;
                time = 1f;

            }
                
        }
            
        
    }

    bool validarEnemigoActivo(List<GameObject> EnemyPool){
        float CountActive = 0;
        for(int i = 0; i< EnemyPool.Count; i++){
            if(EnemyPool[i].activeSelf){
                CountActive += 1;
            }
        }
        if(CountActive == Poolsize){
            return true;
        }
        return false;
    }
}

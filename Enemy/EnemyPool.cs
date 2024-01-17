using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyPool instance;

    private float CountFloat;

    private float distance;
    private float distanceSuccubus;

    //

    private GameObject activePlayer;
    public GameObject player;

    public GameObject playerSoul;

    //
    [SerializeField] public GameObject[] EnemyPoolSlime;

    [SerializeField] public GameObject[] EnemyPoolNatureX;

    [SerializeField] public GameObject[] EnemyPoolSuccubus;
    public GameObject EnemyBoss;

    
    private void Awake(){
        instance = this;
    }

    void Start()
    {
        EnemyPoolSlime = GameObject.FindGameObjectsWithTag("EnemySlime");
        EnemyBoss = GameObject.FindGameObjectWithTag("EnemyBoss1");
        EnemyPoolSuccubus = GameObject.FindGameObjectsWithTag("Succubus");
        EnemyPoolNatureX = GameObject.FindGameObjectsWithTag("EnemyNature");

        if(EnemyBoss != null){
            EnemyBoss.SetActive(false);
        }
        

        for(int i = 0; i < EnemyPoolSuccubus.Length; i++){
            EnemyPoolSuccubus[i].GetComponent<Transform>().parent = transform;
            EnemyPoolSuccubus[i].SetActive(false);

        }


        for(int i = 0 ; i < EnemyPoolSlime.Length ; i++){

            EnemyPoolSlime[i].GetComponent<Transform>().parent = transform;
            EnemyPoolSlime[i].GetComponent<EnemySlime>().Health = EnemyPoolSlime[i].GetComponent<StatsEnemy>().HP;
            EnemyPoolSlime[i].SetActive(false);

        }

        for(int i = 0; i< EnemyPoolNatureX.Length ; i ++){

            EnemyPoolNatureX[i].GetComponent<Transform>().parent = transform;
            EnemyPoolNatureX[i].GetComponent<EnemyNature>().Health = EnemyPoolNatureX[i].GetComponent<StatsEnemy>().HP;
            EnemyPoolNatureX[i].SetActive(false);

        }
    }

    private void BossActive(){

        if(EnemyBoss != null){
            float distance = Mathf.Abs(activePlayer.transform.position.x - EnemyBoss.transform.position.x);

            if(distance < 30f){
                EnemyBoss.SetActive(true);

            }

            if(StatsEnemyBoss.instance.HP <= 0){
                EnemyBoss.SetActive(false);
            }
        }

    }

    private void SuccubusActive(){

        for(int i = 0; i < EnemyPoolSuccubus.Length; i++){

            float val = EnemyPoolSuccubus[i].GetComponent<StatsEnemy>().HP;
            
            distanceSuccubus = Mathf.Abs(activePlayer.transform.position.x - EnemyPoolSuccubus[i].transform.position.x);
            
            if(distanceSuccubus < 12f && val > 0){

                EnemyPoolSuccubus[i].SetActive(true);
            }else{
                EnemyPoolSuccubus[i].SetActive(false);
            }

        }

    }

    private void EnemyNatureXActive(){
        for(int i = 0 ; i < EnemyPoolNatureX.Length ; i ++){

            float val = EnemyPoolNatureX[i].GetComponent<EnemyNature>().Health;
            distance = Mathf.Abs(activePlayer.transform.position.x - EnemyPoolNatureX[i].transform.position.x);

            if(distance < 12f && val > 0){

                EnemyPoolNatureX[i].SetActive(true);

            }else{

                EnemyPoolNatureX[i].SetActive(false);

            }

        }

    }

    private void SlimeActive(){

        for(int i = 0 ; i < EnemyPoolSlime.Length ; i++){

            float val = EnemyPoolSlime[i].GetComponent<EnemySlime>().Health;
            
            distance = Mathf.Abs(activePlayer.transform.position.x - EnemyPoolSlime[i].transform.position.x);

            if( distance < 12f && val > 0){

                EnemyPoolSlime[i].SetActive(true);

            }else {
                EnemyPoolSlime[i].SetActive(false);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        // validar estado de palyer (estado fisico y soul)
        if(player.activeSelf == true){
            activePlayer = player;
        }else if (playerSoul.activeSelf == true){
            activePlayer = playerSoul;
        }

        // ejecucion de metodos
        SlimeActive();
        SuccubusActive();
        EnemyNatureXActive();

        BossActive();
        /*
        EnemyPoolSlime = GameObject.FindGameObjectsWithTag("EnemySlime");
        for(int i = 0 ; i < EnemyPoolSlime.Length ; i++){
            EnemyPoolSlime[i].GetComponent<Transform>().parent = transform;
        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsEnemyBoss : MonoBehaviour
{
    public static StatsEnemyBoss instance;

    public  float ATK;
    public  float DEF;
    public  float LVL;
    public  float HP;

    //public TextMeshPro Level;

    void Awake()
    {
        instance = this;
    }
    

    void Start(){
        CalculateLVL();
        //Level.SetText("LVL "+LVL);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CalculateLVL(){

        HP = HP + (LVL * 2);
        ATK = ATK + LVL;
        DEF = DEF + LVL;

    }
}

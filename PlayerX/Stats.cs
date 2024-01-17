using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    public static Stats instance;
    // HP
    public float MAXHP;
    public float CURRENTHP;
    // MP
    public float MAXMP;
    public float CURRENTMP;

    //STATS
    public float ATK;
    public float DEF;
    public float SPD;
    public float EXP;
    public float LVL;
    public float MAXEXP = 10;

    public TextMeshProUGUI NV;

    public GameObject effectLevelUp;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        effectLevelUp.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        NV.SetText(LVL.ToString());

        calcularLVL();
        
        if(CURRENTMP <= 0){
            CURRENTMP = 0;
        }

        if(CURRENTMP > MAXMP){
            CURRENTMP = MAXMP;
        }

        if(CURRENTHP > MAXHP){
            CURRENTHP = MAXHP;
        }

    }

    void calcularLVL(){

        if(EXP > MAXEXP){
            effectLevelUp.SetActive(true);
            LVL++;
            MAXEXP = MAXEXP + (LVL * 10);

            if(validarPrimo(LVL) == true){
                MAXHP = MAXHP + LVL; 
                ATK = Mathf.RoundToInt(ATK + (LVL *0.5f));
            }

            float val = Random.Range(1,4);

            switch (val)
            {
                case 1:
                    ATK = Mathf.RoundToInt(ATK + (LVL *0.5f));
                break;

                case 2:
                    DEF = DEF + LVL;
                break;

                case 3:
                    MAXMP = MAXMP + LVL;
                break;

                case 4:
                    SPD = SPD + LVL;
                break;

            }
        

        }


    }

    bool validarPrimo(float num){

        if(num == 0 || num == 1 || num == 4) return false;

        for(int i = 2; i < num /2; i ++){
            if(num % i == 0) return false;
        }

        return true;
    }
    


}

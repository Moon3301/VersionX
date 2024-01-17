using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobyController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI TextLevel;
    public TextMeshProUGUI TextName;

    public TextMeshProUGUI TextEXP;

    public TextMeshProUGUI TextCountGold;
    public TextMeshProUGUI TextCountDiamond;

    public float HP;
    public float MP;
    public float LVL;
    public float EXP;
    public float ATK;
    public float DEF;

    public float Gold;
    public float Diamond;

    // validate

    private bool ActiveLoadData;


    void Start()
    {
        ActiveLoadData = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ActiveLoadData == true){
            LoadDataPlayer();
            SetDataPlayer();
            ActiveLoadData = false;

        }

        
    }

    public void SetDataPlayer(){

        TextLevel.SetText(LVL.ToString());
        TextEXP.SetText(EXP.ToString());
        TextCountGold.SetText(Gold.ToString());
        TextCountDiamond.SetText(Diamond.ToString());
        
    }

    public void LoadDataPlayer(){

        LoadStatsPlayer();
        LoadItemsPlayer();

    }

    public void LoadStatsPlayer(){

        HP = PlayerPrefs.GetFloat("PlayerHP",0);
        MP = PlayerPrefs.GetFloat("PlayerMP",0);
        LVL = PlayerPrefs.GetFloat("PlayerLVL",0);
        EXP = PlayerPrefs.GetFloat("PlayerEXP",0);
        ATK = PlayerPrefs.GetFloat("PlayerATK",0);
        DEF = PlayerPrefs.GetFloat("PlayerDEF",0);

    }

    public void LoadItemsPlayer(){

        Gold = PlayerPrefs.GetFloat("PlayerGold",0);
        Diamond = PlayerPrefs.GetFloat("PlayerDiamond",0);

    }

    public void LoadStarObtainedLVL(){
        PlayerPrefs.SetFloat("StarObtainedLVL1",0);
    }



}

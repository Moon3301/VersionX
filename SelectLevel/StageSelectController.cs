using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageSelectController : MonoBehaviour
{
    // Start is called before the first frame update
    public static StageSelectController instance;

    private bool level1;
    private bool level2;
    private bool level3;
    private bool level4;
    private bool level5;
    private bool level6;
    private bool level7;
    private bool level8;
    private bool level9;
    private bool level10;
    private bool level11;
    private bool level12;
    private bool level13;
    private bool level14;
    private bool level15;
    private bool level16;
    private bool level17;
    private bool level18;

    public TextMeshProUGUI CountStarText;

    private float countLevelStar = 0;
    
    // 
    [SerializeField] private GameObject[] LevelPool;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        LevelPool = GameObject.FindGameObjectsWithTag("Level");

        StageVerifyGame();
        UnlockNextLevel();
        CountStarText.SetText(countLevelStar+"<color=#beb5b6> / 54</color>");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StageVerifyGame(){

        float StarLevel = 0;

        for(int i = 0; i < LevelPool.Length; i++){

            if(PlayerPrefs.GetString("Level"+(i+1)) == "Complete"){

                StarLevel = PlayerPrefs.GetFloat("StarLVL"+(i+1),0);

                if(StarLevel >= 1){

                    LevelPool[i].transform.GetChild(0).transform.GetChild(1).transform.GetChild(1).
                    transform.GetChild(0).gameObject.SetActive(true);
                }

                if(StarLevel >= 2){

                    LevelPool[i].transform.GetChild(0).transform.GetChild(1).transform.GetChild(1).
                    transform.GetChild(1).gameObject.SetActive(true);
                }

                if(StarLevel >= 3){

                    LevelPool[i].transform.GetChild(0).transform.GetChild(1).transform.GetChild(1).
                    transform.GetChild(2).gameObject.SetActive(true);
                }

                countLevelStar +=StarLevel;

            }
        }

    }

    public void UnlockNextLevel(){

        for(int i = 1; i < LevelPool.Length; i++){
            
            if(PlayerPrefs.GetString("Level"+i) == "Complete"){
                LevelPool[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            
        }

    }


}

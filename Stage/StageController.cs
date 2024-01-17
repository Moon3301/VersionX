using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    // Start is called before the first frame update

    public static StageController instance;
    public GameObject enemyBoss;

    public GameObject enemyBossTutorial;
    public GameObject PanelStageClear;
    public GameObject CanvasController;

    public float countStar;
    public float EnemyKillNecesary;

    public bool secretItem1 = false;

    public bool secretItem2 = false;

    public bool CompleteAchivement1 = false;
    public bool CompleteAchivement2 = false;
    public bool CompleteAchivement3 = false;

    public float LevelNumber;

    public float time;

    void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        LoadDataPlayer();
        PanelStageClear.SetActive(false);
        CanvasController.SetActive(true);
        

    }

    // Update is called once per frame
    void Update()
    {
        if(enemyBoss != null){

            if(enemyBoss.GetComponent<StatsEnemyBoss>().HP <= 0){

            StartCoroutine(ActiveStageClear());
            

            }
        }


        
        
        Achievements();

    }

    void EnablePanelStageClear(){

        CanvasController.SetActive(false);
        PanelStageClear.SetActive(true);

    }

    public void Achievements(){

        if(enemyBoss != null){
            if(StatsEnemyBoss.instance.HP <= 0  && CompleteAchivement1 == false){
            
            countStar += 1;
            CompleteAchivement1 = true;
            }
        }

        if(enemyBossTutorial != null){
            if(enemyBossTutorial.GetComponent<StatsEnemy>().HP <= 0  && CompleteAchivement1 == false){
                countStar += 1;
                CompleteAchivement1 = true;
            }
        }


        
        
        if(secretItem1 == true && secretItem2 == true && CompleteAchivement2 == false){

            countStar += 1;
            CompleteAchivement2 = true;

        }
        
        if(PlayerW.instance.CountEnemyDefeat >= EnemyKillNecesary && CompleteAchivement3 == false){

            countStar += 1;
            CompleteAchivement3 = true;

        }

    }

    public IEnumerator ActiveStageClear(){


        yield return new WaitForSeconds(time);
        EnablePanelStageClear();

    }

    public void SaveDataLVL(){

        SaveStatsPlayer();
        SaveItemsPlayer();
        SaveStarObtainedLVL();
    }

    public void SaveStatsPlayer(){

        float hp = PlayerPrefs.GetFloat("PlayerHP",0);
        float mp = PlayerPrefs.GetFloat("PlayerMP",0);
        float lvl = PlayerPrefs.GetFloat("PlayerLVL",0);
        float exp = PlayerPrefs.GetFloat("PlayerEXP",0);
        float atk = PlayerPrefs.GetFloat("PlayerATK",0);
        float def = PlayerPrefs.GetFloat("PlayerDEF",0);

        PlayerPrefs.SetFloat("PlayerHP",Stats.instance.MAXHP);
        PlayerPrefs.SetFloat("PlayerMP",Stats.instance.MAXMP);
        PlayerPrefs.SetFloat("PlayerLVL",Stats.instance.LVL);
        PlayerPrefs.SetFloat("PlayerEXP",Stats.instance.EXP);
        PlayerPrefs.SetFloat("PlayerATK",Stats.instance.ATK);
        PlayerPrefs.SetFloat("PlayerDEF",Stats.instance.DEF);

    }

    public void SaveItemsPlayer(){

        float gold = PlayerPrefs.GetFloat("PlayerGold", 0);
        float Diamond = PlayerPrefs.GetFloat("PlayerDiamond",0);

        PlayerPrefs.SetFloat("PlayerGold",Inventario.instance.Gold + gold);
        PlayerPrefs.SetFloat("PlayerDiamond",Inventario.instance.Diamond + Diamond);

    }

    public void SaveStarObtainedLVL(){

        PlayerPrefs.SetFloat("StarLVL"+LevelNumber,countStar);

    }

    public void LoadDataPlayer(){

        Stats.instance.MAXHP = PlayerPrefs.GetFloat("PlayerHP",0);
        Stats.instance.MAXMP = PlayerPrefs.GetFloat("PlayerMP",0);
        Stats.instance.ATK = PlayerPrefs.GetFloat("PlayerATK",0);
        Stats.instance.DEF = PlayerPrefs.GetFloat("PlayerDEF",0);
        Stats.instance.EXP = PlayerPrefs.GetFloat("PlayerEXP",0);
        Stats.instance.LVL = PlayerPrefs.GetFloat("PlayerLVL",0);


    }

    public void LevelComplete(){

        if(enemyBossTutorial == null){
            PlayerPrefs.SetString("Level"+LevelNumber,"Complete");
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PanelStageClear : MonoBehaviour
{
    // Star 1
    public GameObject star1;
    public GameObject effectStar1;
    // Star 2
    public GameObject star2;
    public GameObject effectStar2;

    // Star 3
    public GameObject star3;
    public GameObject effectStar3;

   
    public string LobbyMenu;

    // rewards obtain

    public TextMeshProUGUI reward1;
    public TextMeshProUGUI reward2;
    public TextMeshProUGUI reward3;
    public TextMeshProUGUI reward4;


    // Start is called before the first frame update
    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        effectStar1.SetActive(false);
        effectStar2.SetActive(false);
        effectStar3.SetActive(false);
        
    }

    void OnEnable(){

        
        
        CalculateRewards();
         
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(StateStar());
        
    }


    public void ReturnToLobby(){

        LevelState.LoadLevel(LobbyMenu);
        
        StageController.instance.LevelComplete();
    }

    public IEnumerator StateStar(){

        yield return new WaitForSeconds(0.8f);

        if(StageController.instance.countStar >= 1){
            star1.SetActive(true);
            effectStar1.SetActive(true);
        }

        yield return new WaitForSeconds(0.8f);

        if(StageController.instance.countStar >= 2){
            star2.SetActive(true);
            effectStar2.SetActive(true);
        }

        yield return new WaitForSeconds(0.8f);

        if(StageController.instance.countStar >= 3){
            star3.SetActive(true);
            effectStar3.SetActive(true);
        }



    }

    public void CalculateRewards(){

        float AmountRewardGold = 0;
        float AmountRewardDiamond= 0;
        float AmountRewardGear= 0;
        float AmountRewardEnergy= 0;


        if(StageController.instance.countStar == 1){

            AmountRewardGold = Random.Range(10,20);
            AmountRewardDiamond = Random.Range(1,3);
            AmountRewardGear = Random.Range(1,3);
            AmountRewardEnergy = Random.Range(1,2);

        }

        if(StageController.instance.countStar == 2){

            AmountRewardGold = Random.Range(15,30);
            AmountRewardDiamond = Random.Range(2,6);
            AmountRewardGear = Random.Range(2,6);
            AmountRewardEnergy = Random.Range(1,3);
        }

        if(StageController.instance.countStar == 3){

            AmountRewardGold = Random.Range(20,40);
            AmountRewardDiamond = Random.Range(3,9);
            AmountRewardGear = Random.Range(3,9);
            AmountRewardEnergy = Random.Range(2,4);
            
        }

        reward1.SetText(AmountRewardGear.ToString());
        reward2.SetText(AmountRewardDiamond.ToString());
        reward3.SetText(AmountRewardGold.ToString());
        reward4.SetText(AmountRewardEnergy.ToString());

    }


}

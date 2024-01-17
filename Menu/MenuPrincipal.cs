using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update

    public string Lobby;

    public GameObject TapToStart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame(){

        LevelState.LoadLevel(Lobby);
        Time.timeScale = 1f;

        StageDataNewGame();

    }

    public void ContinueGame(){

        LevelState.LoadLevel(Lobby);
        Time.timeScale = 1f;
        

    }


    public void DesactivateTaptoStart(){

        TapToStart.SetActive(false);

    }

    public void StageDataNewGame(){
        
        // llamar solo 1 vez al iniciar nuevo juego

        // Restart Levels
        PlayerPrefs.SetString("Level1","Pending");
        PlayerPrefs.SetString("Level2","Pending");
        PlayerPrefs.SetString("Level3","Pending");
        PlayerPrefs.SetString("Level4","Pending");
        PlayerPrefs.SetString("Level5","Pending");
        PlayerPrefs.SetString("Level6","Pending");
        PlayerPrefs.SetString("Level7","Pending");
        PlayerPrefs.SetString("Level8","Pending");
        PlayerPrefs.SetString("Level9","Pending");
        PlayerPrefs.SetString("Level10","Pending");
        PlayerPrefs.SetString("Level11","Pending");
        PlayerPrefs.SetString("Level12","Pending");
        PlayerPrefs.SetString("Level13","Pending");
        PlayerPrefs.SetString("Level14","Pending");
        PlayerPrefs.SetString("Level15","Pending");
        PlayerPrefs.SetString("Level16","Pending");
        PlayerPrefs.SetString("Level17","Pending");
        PlayerPrefs.SetString("Level18","Pending");

        // Reset Star Level
        PlayerPrefs.SetFloat("StarLVL1",0);
        PlayerPrefs.SetFloat("StarLVL2",0);
        PlayerPrefs.SetFloat("StarLVL3",0);
        PlayerPrefs.SetFloat("StarLVL4",0);
        PlayerPrefs.SetFloat("StarLVL5",0);
        PlayerPrefs.SetFloat("StarLVL6",0);
        PlayerPrefs.SetFloat("StarLVL7",0);
        PlayerPrefs.SetFloat("StarLVL8",0);
        PlayerPrefs.SetFloat("StarLVL9",0);
        PlayerPrefs.SetFloat("StarLVL10",0);
        PlayerPrefs.SetFloat("StarLVL11",0);
        PlayerPrefs.SetFloat("StarLVL12",0);
        PlayerPrefs.SetFloat("StarLVL13",0);
        PlayerPrefs.SetFloat("StarLVL14",0);
        PlayerPrefs.SetFloat("StarLVL15",0);
        PlayerPrefs.SetFloat("StarLVL16",0);
        PlayerPrefs.SetFloat("StarLVL17",0);
        PlayerPrefs.SetFloat("StarLVL18",0);

        // Stats jugador
        PlayerPrefs.SetFloat("PlayerHP",10);
        PlayerPrefs.SetFloat("PlayerMP",15);
        PlayerPrefs.SetFloat("PlayerLVL",1);
        PlayerPrefs.SetFloat("PlayerEXP",0);
        PlayerPrefs.SetFloat("PlayerATK",3);
        PlayerPrefs.SetFloat("PlayerDEF",1);

        // pickUp jugador
        PlayerPrefs.SetFloat("PlayerGold",0);
        PlayerPrefs.SetFloat("PlayerDiamond",0);

        // Tutorial

        PlayerPrefs.SetString("Tutorial","Pending");

    }


}

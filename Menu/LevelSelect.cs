using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    public string level1;
    public string level2;
    public string level3;
    public string level4;
    public string level5;
    public string level6;
    public string level7;

    public string retroceder;


    public void Level1(){

        LevelState.LoadLevel(level1);
        Time.timeScale = 1f;
    }

    public void Level2(){
        LevelState.LoadLevel(level2);
        Time.timeScale = 1f;
    }

    public void Level3(){
        LevelState.LoadLevel(level3);
        Time.timeScale = 1f;
    }

    public void Level4(){
        LevelState.LoadLevel(level4);
        Time.timeScale = 1f;
    }

    public void Level5(){
        LevelState.LoadLevel(level5);
        Time.timeScale = 1f;
    }

    public void Retroceder(){
        SceneManager.LoadScene(retroceder);
        Time.timeScale = 1f;
    }


}

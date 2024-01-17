using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLobby : MonoBehaviour
{
    // Start is called before the first frame update
    public string levelSelect;
    public string Tutorial;

    public string Inventory;

    public GameObject PopUpTutorial;
    void Start()
    {
        PopUpTutorial.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    public void GoToInventory(){
        SceneManager.LoadScene(Inventory);
        Time.timeScale = 1f;
    }

    public void NewGame(){
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void TutorialGame(){
        LevelState.LoadLevel(Tutorial);
        Time.timeScale = 1f;
    }

    public void SelectLevel(){

        string val = PlayerPrefs.GetString("Tutorial","Sin datos");

        if(val == "Pending"){
            PopUpTutorial.SetActive(true);
        }else if (val == "Complete"){
            NewGame();
        }


    }
}

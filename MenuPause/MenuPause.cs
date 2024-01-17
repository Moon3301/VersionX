using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public static MenuPause instance;
    public GameObject pauseScreen, inventory;
    public bool isPaused;
    public string levelSelect, mainMenu;

    public GameObject popUpWarning;
    void Awake()
    {
        instance = this;
    }

    void Start(){
        popUpWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            PauseUnPause();
        }
    }

    public void PauseUnPause()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LevelSelect(){

        LevelState.LoadLevel(levelSelect);
        Time.timeScale = 1f;
    }

    public void PopUpWarningLossStats(){

        popUpWarning.SetActive(true);

    }

    public void ClosePopUpWarning(){
        popUpWarning.SetActive(false);
    }

    public void MainMenu(){
        
        LevelState.LoadLevel(mainMenu);
        Time.timeScale = 1f;
    }

    public void InventoryMenuOn(){
        inventory.SetActive(true);

    }

    public void InventoryMenuOff(){
        inventory.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelState
{
    // Start is called before the first frame update
    public static string nextScene;
    public static void LoadLevel(string name){

        nextScene = name;

        SceneManager.LoadScene("LoadingScene");

    }

}

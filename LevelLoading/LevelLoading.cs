using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoading : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelLoading instance;

    public Slider SliderLoading;
    public TextMeshProUGUI TextSlider;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        string levelToLoad = LevelState.nextScene;
        StartCoroutine(this.LoadingLevel(levelToLoad));
    }

    private void OnDisable() {
        SliderLoading.value = 0;
        TextSlider.SetText("Loading... "+SliderLoading.value+"%");


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(operation.isDone == true){

            SliderLoading.value = 100;
            TextSlider.SetText("Loading... "+SliderLoading.value+"%");

            ScreenLoading.SetActive(false);
            
        }
        */
    }

    public IEnumerator LoadingLevel(string nameLevel){

        yield return new WaitForSeconds(0.5f);
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameLevel);

        while(operation.isDone == false){

            SliderLoading.value = 90;
            TextSlider.SetText("Loading... "+SliderLoading.value+"%");
            yield return null;
        }

    }



}

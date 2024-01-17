using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{

    public static ProgressBar instance;

    //HP
    public float MinHp;
    public float MaxHp;
    public float currentHp;

    //public Image mask;
    public Slider sliderHp;

    //MP

    public float MinMp;
    public float MaxMp;
    public float currentMp;

    public Slider sliderMp;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentHp = Stats.instance.CURRENTHP;
        MaxHp = Stats.instance.MAXHP;

        currentMp = Stats.instance.CURRENTMP;
        MaxMp = Stats.instance.MAXMP;



        GetCurrentFillHP();
        GetCurrentFillMP();
        
    }

    void GetCurrentFillHP(){

        float currentOffSet = currentHp - MinHp;
        float maxOffSet = MaxHp - MinHp;
        float fillAmount = (float)currentOffSet / (float)maxOffSet;
        //mask.fillAmount = fillAmount;

        sliderHp.value = fillAmount;

    }

    void GetCurrentFillMP(){
        
        float currentOffSet = currentMp - MinMp;
        float maxOffSet = MaxMp - MinMp;
        float fillAmount = (float)currentOffSet / (float)maxOffSet;

        sliderMp.value = fillAmount;

    }
}

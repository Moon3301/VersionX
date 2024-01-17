using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    // Start is called before the first frame update
    public static SkillController instance;
    public GameObject buttonBullet;
    public GameObject buttonShield;
    public GameObject buttonSmoke;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //bullet
    public void ActiveButtonBullet(){
        buttonBullet.SetActive(true);
    }

    public void DesactiveButtonBullet(){
        buttonBullet.SetActive(false);
    }

    //Shield
    public void ActiveButtonShield(){
        buttonShield.SetActive(true);
    }

    public void DesactiveButtonShield(){
        buttonShield.SetActive(false);
    }

    //Smoke

    public void ActiveButtonSmoke(){
        buttonSmoke.SetActive(true);
    }

    public void DesactiveButtonSmoke(){
        buttonSmoke.SetActive(false);
    }

}

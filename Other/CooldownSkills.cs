using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CooldownSkills : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject btnMoveHorizontal;
    private bool isActive;

    private float time = 2f;
    void Start()
    {
        isActive = btnMoveHorizontal.GetComponent<Button>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        btnMoveHorizontal.GetComponent<Button>().enabled = isActive;
        CooldDownForceHorizontal();

        if(isActive == false){
            time -= Time.deltaTime;
            if(time <0){
                isActive = true;
                time = 2f;
            }
        }
    }

    public void CooldDownForceHorizontal(){
        
        if(PlayerW.instance.forceHorizontal == true){

            isActive = false;

        }
    }





}

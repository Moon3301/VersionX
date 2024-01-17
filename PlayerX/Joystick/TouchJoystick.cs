using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJoystick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RightJoystick;

    public GameObject LeftJoystick;

    public GameObject UpJoystick;

    public GameObject DownJoystick;

    public Joystick JoystickScript;

    public float Horizontal;
    public float Vertical;
    void Start()
    {
        RightJoystick.SetActive(false);
        LeftJoystick.SetActive(false);
        UpJoystick.SetActive(false);
        DownJoystick.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        // activar joystick izquierdo
        Horizontal = JoystickScript.Horizontal;
        Vertical = JoystickScript.Vertical;

        // validar si playerW esta activo


        if(PlayerW.instance.gameObject.activeSelf){

            if(Horizontal > 0){
            RightJoystick.SetActive(true);
            LeftJoystick.SetActive(false);
            UpJoystick.SetActive(false);
            DownJoystick.SetActive(false);
            }

            if(Horizontal < 0){
            RightJoystick.SetActive(false);
            LeftJoystick.SetActive(true);
            UpJoystick.SetActive(false);
            DownJoystick.SetActive(false);
            }

            if(Horizontal == 0){
            RightJoystick.SetActive(false);
            LeftJoystick.SetActive(false);
            UpJoystick.SetActive(false);
            DownJoystick.SetActive(false);
            }


        }else {

            if(Horizontal > 0){
            RightJoystick.SetActive(true);
            LeftJoystick.SetActive(false);
            UpJoystick.SetActive(false);
            DownJoystick.SetActive(false);
            }

            if(Horizontal < 0){
            RightJoystick.SetActive(false);
            LeftJoystick.SetActive(true);
            UpJoystick.SetActive(false);
            DownJoystick.SetActive(false);
            }

            if(Horizontal == 0){
            RightJoystick.SetActive(false);
            LeftJoystick.SetActive(false);
            UpJoystick.SetActive(false);
            DownJoystick.SetActive(false);
            }

            if(Vertical > 0){
            RightJoystick.SetActive(false);
            LeftJoystick.SetActive(false);
            UpJoystick.SetActive(true);
            DownJoystick.SetActive(false);
            }

            if(Vertical < 0){
            RightJoystick.SetActive(false);
            LeftJoystick.SetActive(false);
            UpJoystick.SetActive(false);
            DownJoystick.SetActive(true);
            }

            if(Vertical == 0){
            RightJoystick.SetActive(false);
            LeftJoystick.SetActive(false);
            UpJoystick.SetActive(false);
            DownJoystick.SetActive(false);
            }


        }

        

        



        
    }

  
}

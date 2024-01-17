using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialController : MonoBehaviour
{
    // Start is called before the first frame update
    public static TutorialController instance;

    public GameObject fairyDarzula;

    public GameObject PanelTutorial;

    public TextMeshProUGUI TextTutorial;

    public GameObject BossSuccubus;

    // GUI canvas

    public GameObject BtnJump;
    public GameObject BtnAttack;
    public GameObject BtnVelocity;
    public GameObject BtnMagicAttack;

    public GameObject BtnAttackDown;
    public GameObject BtnRight;
    public GameObject BtnLeft;

    // Focus 

    public GameObject focusbtnAttack;
    public GameObject focusbtnJump;
    public GameObject focusbtnVelocity;
    public GameObject focusbtnMagicAttack;

    public GameObject focusbtnMovement;

    public GameObject focusbtnAttackDown;

    // 

    public bool Tutorial_attack;
    public bool Tutorial_jump;
    public bool Tutorial_velocity;
    public bool Tutorial_magicAttack;

    public bool Tutorial_Movement;
    public bool Tutorial_MovementFinal;

    public bool Tutorial_AttackDown;

    

    //

    public TextMeshProUGUI text;

    public GameObject ParticleVFX;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        BtnJump.SetActive(false);
        BtnAttack.SetActive(false);
        BtnVelocity.SetActive(false);
        BtnMagicAttack.SetActive(false);
        BtnAttackDown.SetActive(false);
        BtnRight.SetActive(false);
        BtnLeft.SetActive(false);

        //Tutorial_Movement = true;
        TutorialMovement();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Tutorial_Movement == true){
            TutorialMovement();
        }
        */
        
        if(Tutorial_attack == true){
            TutorialAttack();
        }

        if(Tutorial_jump == true){
            
            TutorialJump();
            
        }
   
        if(Tutorial_magicAttack == true){
            TutorialMagicAttack();
        }

        if(Tutorial_velocity == true){
            TutorialVelocity();
        }

        if(Tutorial_AttackDown == true){
            TutorialAttackDown();
        }

        if(BossSuccubus.GetComponent<StatsEnemy>().HP <=0 ){
            
            StartCoroutine(StageController.instance.ActiveStageClear());
            PanelTutorial.SetActive(false);
            ClearTutorial();
        }
        
    }

    


    void TutorialMovement(){

        StartCoroutine(CountDownActiveButton());


    }

    IEnumerator CountDownActiveButton(){

        yield return new WaitForSeconds(12f);
        BtnLeft.SetActive(true);
        BtnRight.SetActive(true);
        focusbtnMovement.SetActive(true);
        //Tutorial_Movement = false;
        Tutorial_MovementFinal = true;

    }

    void TutorialAttackDown(){
        focusbtnAttackDown.SetActive(true);
        BtnAttackDown.SetActive(true);   
    }
    
    void TutorialAttack(){

        focusbtnAttack.SetActive(true);
        BtnAttack.SetActive(true);
    }

    void TutorialJump(){
        
        focusbtnJump.SetActive(true);
        BtnJump.SetActive(true);
        
    }

    void TutorialMagicAttack(){
        focusbtnMagicAttack.SetActive(true);
        BtnMagicAttack.SetActive(true);
        
    }

    void TutorialVelocity(){
        focusbtnVelocity.SetActive(true);
        BtnVelocity.SetActive(true);
        
    }

    public void ClearTutorial(){

        PlayerPrefs.SetString("Tutorial","Complete");

    }
    //

    

    IEnumerator CountFinalTutorialMovement(){
        Tutorial_MovementFinal = false;
        ParticleVFX.SetActive(true);
        ParticleVFX.transform.position = focusbtnMovement.transform.position;
        ParticleVFX.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        
        yield return new WaitForSeconds(1f);

        ParticleVFX.SetActive(false);
        focusbtnMovement.SetActive(false);
        

    }

    public void TutorialMovementComplete(){

        if(Tutorial_MovementFinal == true){
            StartCoroutine(CountFinalTutorialMovement());
        }
        


    }

    IEnumerator CountFinalTutorialAttackDown(){

        ParticleVFX.SetActive(true);
        ParticleVFX.transform.position = focusbtnAttackDown.transform.position;
        ParticleVFX.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        yield return new WaitForSeconds(1f);

        ParticleVFX.SetActive(false);
        focusbtnAttackDown.SetActive(false);
        Tutorial_AttackDown = false;

    }

    public void TutorialAttackDownComplete(){
        if(Tutorial_AttackDown == true){
            StartCoroutine(CountFinalTutorialAttackDown());
        }
    }


    IEnumerator CountFinalTutorialAttack(){

        ParticleVFX.SetActive(true);
        ParticleVFX.transform.position = focusbtnAttack.transform.position;
        ParticleVFX.transform.localScale = new Vector3(0.7f,0.7f,0.7f);

        yield return new WaitForSeconds(4f);
        ParticleVFX.SetActive(false);
        focusbtnAttack.SetActive(false);
        Tutorial_attack =false;
    }

    public void TutorialAttackComplete(){
        if(Tutorial_attack == true){
            StartCoroutine(CountFinalTutorialAttack());
        }
        
    }

    //
    IEnumerator CountFinalTutorialMagicAttack(){

        ParticleVFX.SetActive(true);
        ParticleVFX.transform.position = focusbtnMagicAttack.transform.position;
        ParticleVFX.transform.localScale = new Vector3(0.7f,0.7f,0.7f);

        yield return new WaitForSeconds(4f);
        focusbtnMagicAttack.SetActive(false);
        Tutorial_magicAttack =false;
        ParticleVFX.SetActive(false);
    }

    public void TutorialMagicAttackComplete(){

        if(Tutorial_magicAttack == true){
            StartCoroutine(CountFinalTutorialMagicAttack());
        }
        
    }

    //

    IEnumerator CountFinalTutorialJump(){

        
        ParticleVFX.SetActive(true);
        ParticleVFX.transform.position = focusbtnJump.transform.position;
        ParticleVFX.transform.localScale = new Vector3(0.7f,0.7f,0.7f);

        yield return new WaitForSeconds(3f);
        focusbtnJump.SetActive(false);
        Tutorial_jump =false;
        ParticleVFX.SetActive(false);
    }
    public void TutorialJumpComplete(){

        if(Tutorial_jump == true){
            StartCoroutine(CountFinalTutorialJump());
        }
        
    }

    //

    IEnumerator CountFinalTutorialVelocity(){

        ParticleVFX.SetActive(true);
        ParticleVFX.transform.position = focusbtnVelocity.transform.position;
        ParticleVFX.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        
        yield return new WaitForSeconds(2f);
        focusbtnVelocity.SetActive(false);
        Tutorial_velocity = false;
        ParticleVFX.SetActive(false);
    }

    public void TutorialVelocityComplete(){

        if(Tutorial_velocity == true){
            StartCoroutine(CountFinalTutorialVelocity());
        }
        
    }

}

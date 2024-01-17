using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// importar particle system


public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject theSR;

    public GameObject EffectRestoreHp;

    public static CheckPoint instance;

    private void Awake()
    {
        instance = this;
    }

    void Start(){
        EffectRestoreHp.SetActive(false);
        
    }

    void Update() {

        if(EffectRestoreHp.activeSelf == true){
            Stats.instance.CURRENTHP += Time.deltaTime + 5f;
            Stats.instance.CURRENTMP += Time.deltaTime + 3f;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {

            CheckPointController.instance.DesactivateCheckPoints();
            
            ParticleSystem.MainModule main = theSR.GetComponent<ParticleSystem>().main;
            main.startColor = new Color(0, 255, 0, 1);

            CheckPointController.instance.SetSpawnPoint(transform.position + new Vector3(0, 1f, 0));

        }

    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.tag == "Player"){

            EffectRestoreHp.SetActive(true);
            

        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){

            EffectRestoreHp.SetActive(false);

        }
    }

    public void ResetCheckPoint()
    {
        ParticleSystem.MainModule main = theSR.GetComponent<ParticleSystem>().main;
        main.startColor = new Color(0, 85, 255, 85);
        
    }
}

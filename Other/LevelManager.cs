using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float waitToRespawn;

    public static LevelManager instance;

    private float SaveHp;

    private void Awake()
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

    public void RespawnPlayer(){

        StartCoroutine(RespawnPlayerCo());

    }

    IEnumerator RespawnPlayerCo(){

        CameraScripts.instance.ActivePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);

        CameraScripts.instance.ActivePlayer.gameObject.SetActive(true);
        CameraScripts.instance.ActivePlayer.transform.position = CheckPointController.instance.respawnPoint;
        

        if(Stats.instance.CURRENTHP <= 0){
            Stats.instance.CURRENTHP = Stats.instance.MAXHP;
        }
    }
}

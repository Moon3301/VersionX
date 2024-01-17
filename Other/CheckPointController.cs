using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    // Start is called before the first frame update

    public static CheckPointController instance;

    public CheckPoint[] checkPoints;

    public Vector3 respawnPoint;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        checkPoints = FindObjectsOfType<CheckPoint>();   

        respawnPoint = CameraScripts.instance.ActivePlayer.transform.position;
        
    }

    // Update is called once per frame
    public void DesactivateCheckPoints(){

        for(int i = 0 ; i < checkPoints.Length ; i++){
            checkPoints[i].ResetCheckPoint();
        }


    }

    public void SetSpawnPoint(Vector3 point){
        respawnPoint = point;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public static CameraZoom instance;
    public bool ZoomActive;

    public GameObject Target;

    public Camera Cam;

    public float speed;

    private float timeActive = 3f;

    private bool BossZoom;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        BossZoom = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ZoomActive){

            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,4,speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position,Target.transform.position,-10);

            timeActive -= Time.deltaTime;
            if(timeActive <= 0 ){
                ZoomActive = false;
                timeActive = 3f;
            }

        }else if(BossZoom){

            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,7,speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position,Target.transform.position,-10);

        }else {

            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,5,speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position,Target.transform.position,-10);

        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){
            BossZoom = true;
        }

    }


}

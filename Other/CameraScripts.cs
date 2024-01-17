using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject[] Enemies;
    [SerializeField] public GameObject[] EnemyPoolSlime;

    [SerializeField] public GameObject[] EnemyPoolNatureX;

    [SerializeField] public GameObject[] EnemyPoolSuccubus;
    private GameObject EnemyBoss;


    public static CameraScripts instance;
    public GameObject player;

    public GameObject SoulEffect;
    public GameObject ActivePlayer;
    public Transform farBackground, middlePosition;

    private Vector2 lastPos;

    public float slowMotionFactor = 0.2f;

    private bool isTimeSlowed = false;

    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        lastPos = transform.position;

        EnemyPoolSlime = EnemyPool.instance.EnemyPoolSlime;
        EnemyBoss = EnemyPool.instance.EnemyBoss;
        EnemyPoolSuccubus = EnemyPool.instance.EnemyPoolSuccubus;
        EnemyPoolNatureX = EnemyPool.instance.EnemyPoolNatureX;

    }

    // Update is called once per frame
    void Update()
    {

        if(player.activeSelf == true){
            ActivePlayer = player;
            
        }else{
            ActivePlayer = SoulEffect;
        }

        if(SoulEffect.activeSelf == true){
            ActivePlayer = SoulEffect;
        }else{
            ActivePlayer = player;
        }
        
        if(ActivePlayer != null){
            transform.position = new Vector3(ActivePlayer.transform.position.x, ActivePlayer.transform.position.y, transform.position.z);
        }

        // Background movement

        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        middlePosition.position += new Vector3(amountToMove.x * 0.9f , amountToMove.y * 0.9f, 0f) ;
        
        
        lastPos = transform.position;

        // ralentizar el tiempo


         if (Input.GetKeyDown(KeyCode.T))
        {
            SlowDownTime();
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            ResetTime();
        }

        // efecto ralentizar en situacion de batalla


        
    }

    public void SlowDownTime()
    {
        Time.timeScale = slowMotionFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        isTimeSlowed = true;
    }

    public void ResetTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowMotionFactor;
        isTimeSlowed = false;
    }

    public void TimeSlow(float time){

        StartCoroutine(SlowDown(time));
        
    }

    IEnumerator SlowDown(float time){

        if (!isTimeSlowed){

            SlowDownTime();
        }
        yield return new WaitForSeconds(time);
        
        if (isTimeSlowed){
            
            ResetTime();

        }
    }

    private void OnDisable()
    {
        // Asegúrate de restablecer el tiempo si el objeto se deshabilita
        if (isTimeSlowed)
        {
            ResetTime();
        }
    }

    public void FindNearbyEnemies(){





    }


}

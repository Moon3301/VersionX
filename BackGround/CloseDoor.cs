using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{

    public static CloseDoor instance;
    public GameObject DoorEnter;
    public Transform ObjEnter;
    public Transform InicioEnter;
    public GameObject DoorExit;
    public Transform ObjExit;
    public Transform InicioExit;


    public bool activeBlock;

    // Start is called before the first frame update
    void Start()
    {
        activeBlock = false;
        DoorEnter.transform.position = InicioEnter.transform.position;
        DoorExit.transform.position = InicioExit.transform.position;
    }

    private void Awake(){
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if(activeBlock == true){
            DoorEnter.transform.position = Vector2.MoveTowards(DoorEnter.transform.position, ObjEnter.position, 4 * Time.deltaTime);
            DoorExit.transform.position = Vector2.MoveTowards(DoorExit.transform.position, ObjExit.position, 4 * Time.deltaTime);
        }

        if(activeBlock == false){
            DoorEnter.transform.position = Vector2.MoveTowards(DoorEnter.transform.position, InicioEnter.position, 4 * Time.deltaTime);
            DoorExit.transform.position = Vector2.MoveTowards(DoorExit.transform.position, InicioExit.position, 4 * Time.deltaTime);
        }   
        

        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){

            activeBlock = true;
        }


    }
}

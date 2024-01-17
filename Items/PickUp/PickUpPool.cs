using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPool : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] pickUpPool;

    private float CountFloat;

    private float distance;

    public GameObject player;
    

    void Start()
    {                   
        pickUpPool = GameObject.FindGameObjectsWithTag("PickUp");

        for(int i = 0 ; i < pickUpPool.Length ; i++){

            pickUpPool[i].GetComponent<Transform>().parent = transform;

            pickUpPool[i].SetActive(false);
        }
    }

    private void AddBulletToPool(){

        

        for(int i = 0 ; i < pickUpPool.Length ; i++){

            bool val = pickUpPool[i].GetComponent<PickUp>().recogido;
            distance = Mathf.Abs(player.transform.position.x - pickUpPool[i].transform.position.x);

            if( distance < 10f && val == false){

                pickUpPool[i].SetActive(true);

            }else {
                pickUpPool[i].SetActive(false);
            }

        }
            
        
        

    }

    // Update is called once per frame
    void Update()
    {
        AddBulletToPool();
        

        
    }
}

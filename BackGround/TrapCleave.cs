using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCleave : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 1f;
    public GameObject trap;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( trap.activeSelf == false){
            time -= Time.deltaTime;

            if(time <0){
                trap.SetActive(true);
                time = 1f;
            }
        }
        
    }

}

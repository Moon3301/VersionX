using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    public float time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;
        
        if(time < 0){
            gameObject.SetActive(false);
        }
        
    }

    public void OnEnable(){
        time = 1f;
    }
}

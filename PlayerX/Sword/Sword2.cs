using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword2 : MonoBehaviour
{
    // Start is called before the first frame update

    public static Sword2 instance;
    

    public GameObject animAttackSword;

    void Awake()
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

    private void OnTriggerEnter2D(Collider2D collision){




    }

}

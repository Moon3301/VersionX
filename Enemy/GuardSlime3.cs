using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSlime3 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject effect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        Sword sword = other.GetComponent<Sword>();

        if(sword != null){

            Instantiate(effect, transform.position, Quaternion.identity);
            
        }


    }
}

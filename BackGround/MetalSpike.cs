using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalSpike : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;


    private void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerW>().Hit(damage);
        }

    }
}

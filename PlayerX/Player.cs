using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.tag == "Platform"){

            transform.parent = other.gameObject.transform;

        }

    }

    private void OnCollisionExit2D(Collision2D other){

        if(other.gameObject.tag == "Platform"){

            transform.parent = null;

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrap : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            PlayerW.instance.Hit(damage);
        }

        if(other.gameObject.tag == "EnemySlime"){
            EnemySlime.instance.Hit(damage);
        }
    }
}

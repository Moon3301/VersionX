using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBlack : MonoBehaviour
{

    private float lastShoot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(ButtonActivate.instance.animator.GetBool("active") == true){

            if (Time.time > lastShoot + 0.5f)
            {
            Shoot();
            lastShoot = Time.time;
            }

        }

        
        
    }

    void Shoot(){

        GameObject bullet = bulletPoolTurret.instance.requestBullet();
        bullet.transform.position = transform.position + new Vector3(0, 1f, 0);
        bullet.GetComponent<bulletTurret>().SetDirection(Vector3.right);
    }
}

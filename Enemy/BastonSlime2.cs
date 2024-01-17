using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastonSlime2 : MonoBehaviour
{

    public GameObject AttackSlime;
    private float lastShoot;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(animator.GetBool("Attack") == true && Time.time > lastShoot + 1){
            GameObject bullet =  Instantiate(AttackSlime, transform.position + new Vector3(0,1f,0), Quaternion.identity);
            bullet.GetComponent<AttackSlime2>().SetDirection(PlayerW.instance.transform.position - transform.position + new Vector3(0,-1f,0));
            lastShoot = Time.time;
        }
        
    }
}

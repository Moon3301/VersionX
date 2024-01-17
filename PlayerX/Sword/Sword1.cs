using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword1 : MonoBehaviour
{

    public static Sword1 instance;
    private SpriteRenderer sr;

    private Vector3 direction;

    public Animator animator;

    public GameObject ExplosionElectric;
    // Start is called before the first frame update

    

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("Attack", false);

        



        
    }

    public void AttackSword(){
        animator.SetBool("Attack", true);
        GameObject explosion = Instantiate(ExplosionElectric, transform.position + new Vector3(0.4f,-0.3f,0), Quaternion.identity);
        
    }
}

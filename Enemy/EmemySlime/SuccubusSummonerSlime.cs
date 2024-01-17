using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuccubusSummonerSlime : MonoBehaviour
{
    public static SuccubusSummonerSlime instance;
    public GameObject portal;

    public GameObject player;

    private float distance;
    private float distancex;

    public GameObject direction;

    public Animator anim;

    public float timeActivePortal;

    public GameObject Shield;
    

    
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        portal.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(portal.activeSelf == false){
            Shield.SetActive(true);
        }
        
        distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        distancex = (player.transform.position.x - transform.position.x);

        if(distancex > 0){
            direction.transform.localScale = new Vector3(1f,-1f,1f);
        }else{
            direction.transform.localScale = new Vector3(1f,1f,1f);
        }

        if(distance < 10f && portal.activeSelf == false){
            
            timeActivePortal -= Time.deltaTime;

            if(timeActivePortal <= 0){
                SummonPortal();
                portal.SetActive(true);
                Shield.SetActive(false);
                timeActivePortal = 5f;
            }
            
        }


        
    }

   

    void DesactivateAnimTakeDamage(){
        anim.SetBool("TakeDamage", false);
    }

    void SummonPortal(){

        portal.SetActive(true);

    }

    public void Hit(float damage){

        damage -= gameObject.GetComponent<StatsEnemy>().DEF;

        if(damage <= 0){
            damage = 1;
        }

        gameObject.GetComponent<StatsEnemy>().HP -= damage;

        anim.SetBool("TakeDamage", true);

        //text damage
        GameObject textGo = TextDamagePool.instance.requesText();
        textGo.transform.position = transform.position + new Vector3(0,2f,0);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);
        
        //effect damage 

        GameObject effectTextDamage =  effectPoolDamage.instance.requestBullet();
        effectTextDamage.transform.position = transform.position;

        if(gameObject.GetComponent<StatsEnemy>().HP <= 0){

            GameObject effectEdeath = EffectDeathPool.instance.requestBulletBoss();
            effectEdeath.transform.position = transform.position;
            effectEdeath.transform.localScale = new Vector3(3f,3f,3f);

            PlayerW.instance.CountEnemyDefeat += 1;

            portal.SetActive(false);
            Shield.SetActive(false);
            gameObject.SetActive(false);

        }



    }

}

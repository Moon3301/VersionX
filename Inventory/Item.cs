using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string nameItem;
    public string type;
    public bool notify;
    public string rarety;
    public int amount;
    public string description;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void EffectDestroyGold(){

        GameObject effect = DestroyEffectPickUpPool.instance.requestBullet();
        effect.transform.position = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){

            ItemController.instance.AddItemToList(gameObject);
            EffectDestroyGold();
            gameObject.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

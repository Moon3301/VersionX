using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsFilters : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<GameObject> items;

    public GameObject ItemCategoryAll, ItemCategoryWeapon, ItemCategoryDefend, ItemCategoryBuff, ItemCategoryAccesory;


    void Start()
    {
        
    }

    
    private void OnEnable() {
        //items = GameObject.FindGameObjectsWithTag("ItemInventory");
        items = ItemController.instance.itemsInven;
    }
    
    // Update is called once per frame
    void Update()
    {
        //items = ItemController.instance.itemsInven;
        

    }

    public void SelectItemCategory(float val){

        if(val == 1){
            DeleteSelectItem();
            ItemCategoryAll.transform.GetChild(0).gameObject.SetActive(true);
            
            for(int i = 0; i < items.Count; i++){
                if(items[i].gameObject.activeSelf == false){
                    items[i].gameObject.SetActive(true);
                }
                
            }
            
            
        }else if (val == 2){
            DeleteSelectItem();
            ItemCategoryWeapon.transform.GetChild(0).gameObject.SetActive(true);
            ItemCategoryWeapon.transform.GetChild(2).gameObject.SetActive(true);

            filter("Weapon");

        }else if (val == 3){
            DeleteSelectItem();
            ItemCategoryDefend.transform.GetChild(0).gameObject.SetActive(true);
            ItemCategoryDefend.transform.GetChild(2).gameObject.SetActive(true);

            filter("Defense");

        }else if(val == 4){
            DeleteSelectItem();
            ItemCategoryBuff.transform.GetChild(0).gameObject.SetActive(true);
            ItemCategoryBuff.transform.GetChild(2).gameObject.SetActive(true);

            filter("Buff");

        }else if(val ==5){
            DeleteSelectItem();
            ItemCategoryAccesory.transform.GetChild(0).gameObject.SetActive(true);
            ItemCategoryAccesory.transform.GetChild(2).gameObject.SetActive(true);

            filter("Accesory");
        }
        


    }

    public void DeleteSelectItem(){
        ItemCategoryAll.transform.GetChild(0).gameObject.SetActive(false);
        

        ItemCategoryWeapon.transform.GetChild(0).gameObject.SetActive(false);
        ItemCategoryWeapon.transform.GetChild(2).gameObject.SetActive(false);

        ItemCategoryDefend.transform.GetChild(0).gameObject.SetActive(false);
        ItemCategoryDefend.transform.GetChild(2).gameObject.SetActive(false);

        ItemCategoryBuff.transform.GetChild(0).gameObject.SetActive(false);
        ItemCategoryBuff.transform.GetChild(2).gameObject.SetActive(false);

        ItemCategoryAccesory.transform.GetChild(0).gameObject.SetActive(false);
        ItemCategoryAccesory.transform.GetChild(2).gameObject.SetActive(false);

    }

    public void FilterItem(float val){

        for(int i = 0; i < items.Count; i++){
            
            if(val == 1){
                
                items[i].SetActive(true);

            }else if( val == 2){

                if(items[i].GetComponent<ItemInventory>().typeII != "Weapon"){
                    items[i].SetActive(false);
                }
            }else if ( val == 3){
                if(items[i].GetComponent<ItemInventory>().typeII != "Defend"){
                    items[i].SetActive(false);
                }

            }else if ( val == 4){
                if(items[i].GetComponent<ItemInventory>().typeII != "Buff"){
                    items[i].SetActive(false);
                }
            }else if(val == 5){
                if(items[i].GetComponent<ItemInventory>().typeII != "Accesory"){
                    items[i].SetActive(false);
                }
            }
        }
    }

    public void filter(string type){
        for(int i = 0; i < items.Count; i++){

            if(items[i].GetComponent<ItemInventory>().typeII != type){
                items[i].gameObject.SetActive(false);
            }else {
                items[i].gameObject.SetActive(true);
            }
            
        }

    }
}

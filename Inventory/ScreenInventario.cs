using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenInventario : MonoBehaviour
{
    // Start is called before the first frame update

    public static ScreenInventario instance;
    [SerializeField] private GameObject[] items;
    
    public Image ItemImage;

    public TextMeshProUGUI ItemName;

    public TextMeshProUGUI ItemDescripcion;

    public GameObject ItemStats;



    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        
    }

    public void DisableFocusItem(){

        for(int i = 0; i< items.Length; i++){
            items[i].transform.GetChild(3).gameObject.SetActive(false);

        }

    }

    

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == true){
            items = GameObject.FindGameObjectsWithTag("ItemInventory");
            test();
        }


        
        
    }


    public void test(){

        for(int i = 0; i < items.Length ; i++){

            if(items[i].GetComponent<ItemInventory>().focus == true){

                ItemImage.sprite = items[i].GetComponent<ItemInventory>().ItemImage;
                ItemName.SetText(items[i].GetComponent<ItemInventory>().nameItemII);

                if(items[i].GetComponent<ItemInventory>().typeII == "Accesory"){

                    ItemStats.SetActive(false);
                    ItemDescripcion.SetText(items[i].GetComponent<ItemInventory>().descriptionII);


                }



            }


        }


    }
}

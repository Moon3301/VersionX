using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update

    public static ItemController instance;

    public List<GameObject> Items;

    [SerializeField] public List<GameObject> itemsInven;
    //Sprites
    public Sprite itemEye;
    public Sprite itemClaw;
    public Sprite itemPlant;
    public Sprite itemCrystal;
    public Sprite itemPoisonHealth;
    public Sprite itemPoisonMagic;

    // GameObject Rarery
    public GameObject NormalItem;
    public GameObject UnusualItem;
    public GameObject RareItem;
    public GameObject LegendaryItem;
    public GameObject ExoticItem;
    private GameObject ItemCreated;


    // GameObject others
    public GameObject Contents;
    public GameObject Inventory;

    // Item Information

    public Image ImageItem;



    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Inventory.activeSelf == true && Items.Count > 0){

            for(int i = 0; i < Items.Count; i ++){

                if(Items[i].GetComponent<Item>().rarety == "Normal"){
                    ItemCreated = Instantiate(NormalItem);

                    ItemCreated = SetIcon(Items[i], ItemCreated);
                    
                    ItemCreated.GetComponent<ItemInventory>().GetValItems(Items[i].GetComponent<Item>().nameItem,
                    Items[i].GetComponent<Item>().rarety,Items[i].GetComponent<Item>().type,
                    Items[i].GetComponent<Item>().description);

                    

                    ItemCreated.transform.parent = Contents.transform;
                    ItemCreated.GetComponent<Transform>().localScale = new Vector3(1f,1f,1f);

                    itemsInven.Add(ItemCreated);


                }else if(Items[i].GetComponent<Item>().rarety == "Unusual"){
                    ItemCreated = Instantiate(UnusualItem);
                    
                    ItemCreated = SetIcon(Items[i], ItemCreated);

                    ItemCreated.GetComponent<ItemInventory>().GetValItems(Items[i].GetComponent<Item>().nameItem,
                    Items[i].GetComponent<Item>().rarety,Items[i].GetComponent<Item>().type,
                    Items[i].GetComponent<Item>().description);

                    ItemCreated.transform.parent = Contents.transform;
                    ItemCreated.GetComponent<Transform>().localScale = new Vector3(1f,1f,1f);

                    itemsInven.Add(ItemCreated);

                }else if (Items[i].GetComponent<Item>().rarety == "Rare"){
                    ItemCreated = Instantiate(RareItem);

                    ItemCreated = SetIcon(Items[i], ItemCreated);

                    ItemCreated.GetComponent<ItemInventory>().GetValItems(Items[i].GetComponent<Item>().nameItem,
                    Items[i].GetComponent<Item>().rarety,Items[i].GetComponent<Item>().type,
                    Items[i].GetComponent<Item>().description);

                    ItemCreated.transform.parent = Contents.transform;
                    ItemCreated.GetComponent<Transform>().localScale = new Vector3(1f,1f,1f);

                    itemsInven.Add(ItemCreated);

                }else if (Items[i].GetComponent<Item>().rarety == "Legendary"){
                    ItemCreated = Instantiate(LegendaryItem);

                    ItemCreated = SetIcon(Items[i], ItemCreated);

                    ItemCreated.GetComponent<ItemInventory>().GetValItems(Items[i].GetComponent<Item>().nameItem,
                    Items[i].GetComponent<Item>().rarety,Items[i].GetComponent<Item>().type,
                    Items[i].GetComponent<Item>().description);

                    ItemCreated.transform.parent = Contents.transform;
                    ItemCreated.GetComponent<Transform>().localScale = new Vector3(1f,1f,1f);

                    itemsInven.Add(ItemCreated);

                }else if (Items[i].GetComponent<Item>().rarety == "Exotic"){
                    ItemCreated = Instantiate(ExoticItem);

                    ItemCreated = SetIcon(Items[i], ItemCreated);

                    ItemCreated.GetComponent<ItemInventory>().GetValItems(Items[i].GetComponent<Item>().nameItem,
                    Items[i].GetComponent<Item>().rarety,Items[i].GetComponent<Item>().type,
                    Items[i].GetComponent<Item>().description);
                    
                    ItemCreated.transform.parent = Contents.transform;
                    ItemCreated.GetComponent<Transform>().localScale = new Vector3(1f,1f,1f);

                    itemsInven.Add(ItemCreated);
                    
                }

            }
            Items.Clear();


        }
        
    }

    public void ItemInformation(){

        



    }

    public GameObject SetIcon(GameObject item, GameObject itemInventory){

        if(item.GetComponent<Item>().nameItem == "Eye"){
            itemInventory.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemEye;
            itemInventory.GetComponent<ItemInventory>().ItemImage = itemEye;
            
            return itemInventory;
        }else if(item.GetComponent<Item>().nameItem == "Claw"){
            itemInventory.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemClaw;
            itemInventory.GetComponent<ItemInventory>().ItemImage = itemClaw;
            
            return itemInventory;
        }else if(item.GetComponent<Item>().nameItem == "Plant"){
            itemInventory.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemPlant;
            itemInventory.GetComponent<ItemInventory>().ItemImage = itemPlant;
            
            return itemInventory;
        }else if (item.GetComponent<Item>().nameItem == "Crystal"){
            itemInventory.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemCrystal;
            itemInventory.GetComponent<ItemInventory>().ItemImage = itemCrystal;
            
            return itemInventory;
        }else if(item.GetComponent<Item>().nameItem == "PoisonHealth"){
            itemInventory.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemPoisonHealth;
            itemInventory.GetComponent<ItemInventory>().ItemImage = itemPoisonHealth;
           
            return itemInventory;
        }else if(item.GetComponent<Item>().nameItem == "PoisonMagic"){
            itemInventory.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemPoisonMagic;
            itemInventory.GetComponent<ItemInventory>().ItemImage = itemPoisonMagic;
           
            return itemInventory;
        }

        return null;
    }

    public void AddItemToList(GameObject item){

        Items.Add(item);

    }
}

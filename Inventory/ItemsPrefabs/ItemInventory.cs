using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
{
    // Start is called before the first frame update

    public string nameItemII;
    public string raretyII;
    public string typeII;
    public string descriptionII;

    public Sprite ItemImage;

    public bool focus;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.GetChild(3).gameObject.activeSelf == true){
            focus = true;
        }else{
            focus = false;
        }

        
    }

    public void OnClick(){

        ScreenInventario.instance.DisableFocusItem();
        transform.GetChild(3).gameObject.SetActive(true);
        
    }

    
    public void GetValItems(string nameItem, string rarety, string type, string descripcion){

        nameItemII = nameItem;
        raretyII = rarety;
        typeII = type;
        descriptionII = descripcion;
    }
    



}

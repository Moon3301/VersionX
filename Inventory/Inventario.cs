using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventario : MonoBehaviour
{

    public static Inventario instance;
    public TextMeshProUGUI countGold;
    public TextMeshProUGUI countDiamond;

    public TextMeshProUGUI countGoldInventario;
    public TextMeshProUGUI countDiamondInventario;


    public float Gold;
    public float Diamond;

    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        countGold.text = "X"+Gold.ToString();
        countDiamond.text = "X"+Diamond.ToString();

        countGoldInventario.text = "X"+Gold.ToString();
        countDiamondInventario.text = "X"+Diamond.ToString();
        
    }
}

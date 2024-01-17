using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTileMap : MonoBehaviour
{
    // Start is called before the first frame update

    public static BackGroundTileMap instance;

    public bool ChocandoPared;

    void Start()
    {
        
    }

    void Awake()
    {
        instance = this;
    }

    void Update(){
        if(Physics2D.Raycast(transform.position, Vector3.left, 0.5f)){
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "Player"){


            ChocandoPared = true;

            /*
            bool ActiveForce = other.gameObject.GetComponent<PlayerW>().forceHorizontal;
            if(ActiveForce == true){

                float val = other.gameObject.GetComponent<PlayerW>().position.transform.localScale.y;
                Vector2 direction = new Vector2(0,0);

                if(val == -1){
                    direction = Vector2.right;
                }else if (val == 1){
                direction = Vector2.left;
                }
                Debug.Log("CHOCANDO CON LA PARED");
                other.gameObject.GetComponent<PlayerW>().rb.AddForce(direction * 1000f);
            }
            */
        }else{
            ChocandoPared = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{

    public Transform pos1;
    public Transform pos2;
    private bool flag;

    public float velocity;

    public GameObject Plataforma;

    private Vector3 MoverHacia;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos1.position;
        flag = true;

        MoverHacia = pos1.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 objetivo = new Vector2(pos1.position.x, pos1.position.y);
        Vector2 objetivo2 = new Vector2(pos2.position.x, pos2.position.y);

        if(flag == true){
            Vector2 nuevapos = Vector2.MoveTowards(rb.position, objetivo2, velocity * Time.deltaTime); 
            rb.MovePosition(nuevapos);
            if(rb.position == objetivo2){
                flag = false;
            }
        }

        if(flag == false){
            Vector2 nuevapos = Vector2.MoveTowards(rb.position, objetivo, velocity * Time.deltaTime); 
            rb.MovePosition(nuevapos);
            if(rb.position == objetivo){
                flag = true;
            }
        }
        */

        Plataforma.transform.position = Vector2.MoveTowards(Plataforma.transform.position, MoverHacia, velocity * Time.deltaTime);

        if(Plataforma.transform.position == pos1.position){
            MoverHacia = pos2.position;
        }

        if(Plataforma.transform.position == pos2.position){
            MoverHacia = pos1.position;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyDarzula : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    public Rigidbody2D rb;
    public float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        Vector3 direction = player.transform.position - transform.position;
        
        if(direction.x > 0.1f){
            transform.localScale = new Vector3(-0.3f,0.3f,0.3f);
        }else if(direction.x < 0.1f){
            transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        }

        FollowPlayer();


    }

    void FollowPlayer(){

        if(distance > 1f){

            Vector2 objetivo = new Vector2(player.transform.position.x,player.transform.position.y + 1f);
            Vector2 nuevapos = Vector2.MoveTowards(rb.position,objetivo, 3 * Time.deltaTime);
            rb.MovePosition(nuevapos);

        }
    }
}

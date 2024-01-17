using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowSmoke : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rb;
    private float Horizontal;
    private float Vertical;

    public Joystick joystick;

    public float timeHollowSmoke = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Horizontal = joystick.Horizontal; // Input.GetAxis("Horizontal") PC;
        Vertical = joystick.Vertical; // Input.GetAxis("Vertical") PC;
        /*
        if(PlayerW.instance.smoke == true){

            timeHollowSmoke -= Time.deltaTime;

            if(timeHollowSmoke <= 0){
                gameObject.SetActive(false);
                PlayerW.instance.gameObject.SetActive(true);
                PlayerW.instance.gameObject.transform.position = transform.position;
                PlayerW.instance.smoke = false;
                timeHollowSmoke = 5f;
            }
        }


        */
    }

    private void FixedUpdate(){
        rb.velocity  = new Vector2(Horizontal * velocity, Vertical * velocity);
    }
}

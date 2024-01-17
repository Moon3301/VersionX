using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoul : MonoBehaviour
{
    // Start is called before the first frame update
    public float Horizontal;

    public float Vertical;

    public Joystick joystick;

    public float speed;

    public Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = joystick.Horizontal;
        Vertical = joystick.Vertical;
 
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(Horizontal * speed , Vertical * speed);

    }

    public void Hit(){

        PlayerController.instance.DesactiveEffectSoul();

    }
}

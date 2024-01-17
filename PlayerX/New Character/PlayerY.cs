using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerY : MonoBehaviour
{
    //Fisicas
    public Rigidbody2D rb;
    public float speed;
    public float Horizontal;
    private float Vertical;
    public bool Grounded;
    public float JumpForce;
    private bool doubleJump;

    //Animator
    public Animator animator;

    //Joystick
    
    public Joystick joystick;

    //Attack

    private int combo;
    public float timeAttack;
    public bool attack;
    private float lastShoot;

    // position

    public GameObject position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Horizontal > 0){

            position.transform.localScale = new Vector3(1f, -1f, 1f);

        }else if(Horizontal < 0){

            position.transform.localScale = new Vector3(1f, 1f, 1f);

        }

        // 
        animator.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));

        // 
        GameObject sombra = transform.GetChild(1).gameObject;

        if (Physics2D.Raycast(sombra.transform.position, Vector3.down, 0.5f)){
            Grounded = true;
            
        }
        else Grounded = false;

        //

        // Attack

        if(Input.GetKeyDown(KeyCode.A)){

            BasicAttackSword();

        }

        
    }

    private void FixedUpdate(){

        rb.velocity = new Vector2(Horizontal * speed , rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(Grounded){
                Jump();
            }else if (doubleJump){

                rb.velocity = Vector2.zero;
                Jump();
                doubleJump = false;

            }
            
        }

        if( Grounded){
            doubleJump = true;

        }
    }

    private void Jump(){

        animator.SetBool("Jump",true);
        rb.AddForce(Vector2.up * JumpForce);
        
        
    }

    public void BasicAttackSword(){

        animator.SetBool("AttackSword",true);

    }

    public void AnimationJumpFalse(){
        animator.SetBool("Jump",false);
    }

    public void AnimationAttackSwordFalse(){
        animator.SetBool("AttackSword",false);
    }
}

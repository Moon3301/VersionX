using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject bullet;
    private float LastShoot;
    public float distancex;
    public GameObject player;
    public GameObject destroyEffect;
    public Rigidbody2D rb;

    public float velocity;

    //posiciones arma torreta

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;

    public Transform posicion1;
    public Transform posicion2;

    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = posicion1.position;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {

        distancex =  Mathf.Abs(player.transform.position.x - transform.position.x);

        if(distancex < 8f && Time.time > LastShoot + 1f){

            Shoot();
            LastShoot = Time.time;
        }

        

        Vector2 objetivo = new Vector2(posicion1.position.x, posicion1.position.y);
        Vector2 objetivo2 = new Vector2(posicion2.position.x, posicion2.position.y);

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
        
    }

    public void Shoot(){

       

        GameObject bulletClone = Instantiate(bullet, pos1.position , Quaternion.identity);
        bulletClone.GetComponent<bulletTurrent>().SetDirection(Vector3.right);

        GameObject bulletClone2 = Instantiate(bullet, pos2.position , Quaternion.identity);
        bulletClone2.GetComponent<bulletTurrent>().SetDirection(Vector3.left);

        GameObject bulletClone3 = Instantiate(bullet, pos3.position , Quaternion.identity);
        bulletClone3.GetComponent<bulletTurrent>().SetDirection(Vector3.up);

        GameObject bulletClone4 = Instantiate(bullet, pos4.position , Quaternion.identity);
        bulletClone4.GetComponent<bulletTurrent>().SetDirection(Vector3.down);
        

    }
}

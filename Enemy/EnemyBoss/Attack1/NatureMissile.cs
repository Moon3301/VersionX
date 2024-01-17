using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureMissile : MonoBehaviour
{
    // Start is called before the first frame update
    public static NatureMissile instance;
    public Rigidbody2D rb;
    public float Speed;
    public float damage;
    private Vector3 Direction;

    //
    private float lanzadorX;

    private Vector3 Lanzador;

    private Vector3 Target;

    private float targetX;

    public float timeActive = 5f;

    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = Direction * Speed;
        
    }

    void Update()
    {
        
        lanzadorX = Lanzador.x;
        targetX = Target.x;

        float distancia = targetX - lanzadorX;
        float nextX = Mathf.MoveTowards(transform.position.x, targetX, Speed * Time.deltaTime);
        float baseY = Mathf.Lerp(Lanzador.y, Target.y, (nextX - lanzadorX) / distancia);
        float height = 2f*(nextX - lanzadorX) * (nextX - targetX) / (-0.3f * distancia * distancia );

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);

        
        transform.position = movePosition;
        
        if(transform.position == Target){
            EffectDestroyMissile();
           
        }
        
        UsefulLife();
    }
    private void OnEnable() {
        
    }

    private void OnDisable() {
        timeActive = 5f;
    }

    void UsefulLife(){

        timeActive -= Time.deltaTime;

        if(timeActive < 0){
            EffectDestroyMissile();
            timeActive = 5f;
        }
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public static Quaternion LookAtTarget(Vector2 rotation){
        return Quaternion.Euler(0,0,Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

    

    public void GetPosition(Vector3 position, Vector3 positionL){
       Target = position;
       Lanzador = positionL;
       
    }

    public void EffectDestroyMissile(){
        gameObject.SetActive(false);
        GameObject effectDestroy = EffectDestroyNatureMissile.instance.requestEffectDestroy();
        effectDestroy.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other){

        
        if(other.tag == "Player"){
            
            gameObject.SetActive(false);
            other.GetComponent<PlayerW>().Hit(damage);
            
        }
        
        

    }

    // Update is called once per frame
    
}

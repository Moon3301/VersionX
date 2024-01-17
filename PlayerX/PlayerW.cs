using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
//using UnityEngine.UIElements;

public class PlayerW : MonoBehaviour
{
    // Se crea una variable publica estatica para instanciar al jugador en otros objetos
    public static PlayerW instance;

    // 
    public Rigidbody2D rb;
    public float speed;

    public float Horizontal;
    private float Vertical;

   

    //animation 

    public Animator animator;

    // attack

    private int combo;
    public float time ;
    public bool attack;
    public GameObject position;
    public float moveForce;
    private bool force = false;
    private float lastShoot;

    //fisicas

    public float JumpForce;

    public bool Grounded;

    private bool doubleJump;

    //other 


    // Take damage
    public GameObject effectTakeDamage;

    public float TimeActiveShield;

    // Text Damage 
    public GameObject textDamage;

    // force Revert ... Efecto de fuerza repulsiva creada por el jugador 
    // Se crea una variable booleana para validar su estado.

    private bool forceRevert = false;

    // force down ... Efecto de fuerza hacia abajo
    // Crea una variable booleana para validar su estado
    private bool forceDown = false;

    // force Horizontal /... Efecto de fuerza hacia la derecha e izquierda
    // Crea una variable booleana para validar su estado
    public bool forceHorizontal = false;
    private float timeForce = 0.3f;

    // Shield
    public GameObject shield;

    public float timeToUseMP;

    // Contador de enemigos muertos

    public float CountEnemyDefeat;

    public float direccion;

    // 

    public bool OnSlideWalk = false;
    public bool OnStandUpWalk = false;
    public Joystick joystick;

    //

    public float backwardJumpForce = 2.5f; // Fuerza del salto hacia atrás

    public bool forceToBack;

    public float timeToBack = 0.2f;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {   
        shield.SetActive(false);
        effectTakeDamage.SetActive(false);
        forceToBack = false;
        position = transform.GetChild(0).gameObject;
        
    }
    // Update is called once per frame
    void Update()
    {
       
        Attack();
        MoveSpeed();
        MoveSpeedRevert();
        ControllerMPShield();

        /*
        if(Grounded == false){
            btnAttackDown.GetComponent<Button>().interactable = true;
        }else{
            btnAttackDown.GetComponent<Button>().interactable = false;
        }
        */

        // Horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal"); // Input.GetAxis("Horizontal") PC;
        Horizontal = joystick.Horizontal;

        position = transform.GetChild(0).gameObject;

        animator.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
        
        if(Horizontal > 0){
            
            if(OnSlideWalk == true){
                position.transform.localScale = new Vector3(1f, 1f, 1f); // Izquierda
            }else{
                position.transform.localScale = new Vector3(1f, -1f, 1f); // derecha
                direccion = 1;
            }

        }else if(Horizontal < 0){

            if(OnSlideWalk == true){

                position.transform.localScale = new Vector3(1f, -1f, 1f); // Derecha
            }else{
                position.transform.localScale = new Vector3(1f, 1f, 1f); // izquierda
                direccion = -1f; 
            }
            
        }

        // Jump
        GameObject sombra = transform.GetChild(0).transform.GetChild(5).gameObject;
        GameObject sombra2 = transform.GetChild(0).transform.GetChild(0).gameObject;
        
  
        if (Physics2D.Raycast(sombra.transform.position, Vector3.down, 0.5f)|| 
           Physics2D.Raycast(sombra2.transform.position, Vector3.left, 0.5f) || 
           Physics2D.Raycast(sombra2.transform.position, Vector3.right, 0.5f))
        {
        
            Grounded = true;
            
        }
        else Grounded = false;

        RaycastHit2D hitLeft = Physics2D.Raycast(sombra2.transform.position, Vector3.left,0.5f);

        if(hitLeft.collider != null){

            if(Horizontal < 0 && hitLeft.collider.gameObject.tag == "Block"){
                Horizontal = 0;
            }

        }

        RaycastHit2D hitRight = Physics2D.Raycast(sombra2.transform.position, Vector3.right, 0.5f);

        if(hitRight.collider != null){

            if(Horizontal > 0 && hitRight.collider.gameObject.tag == "Block"){
                Horizontal = 0;
            }

        }
            
        /*
        if(Physics2D.Raycast(sombra2.transform.position, Vector3.left,0.5f)){
            if(Horizontal < 0){
                Horizontal = 0;
            }
        }

        if(Physics2D.Raycast(sombra2.transform.position, Vector3.right, 0.5f)){
            
            if(Horizontal > 0){
                Horizontal = 0;
            }
            
        }
        */

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

        if(Input.GetKeyDown(KeyCode.F) && Time.time > lastShoot + 1f){

            animator.SetBool("MagicAttack", true);
            MagicAttack();

            lastShoot = Time.time;
        }
        
        if(shield.activeSelf == true){

            TimeActiveShield += Time.deltaTime;

        }else{
            TimeActiveShield = 0f;
        }

        if(Input.GetKeyDown(KeyCode.N)){

            forceToBack = true;


        }

       
    }

    // END UPDATE

    private void FixedUpdate(){
        rb.velocity = new Vector2(Horizontal * speed , rb.velocity.y);
        ForceHorizontal();
        JumpBack();

        if(attack == true){
            rb.velocity = Vector2.zero;
        }

    }

    // END FIXED UPDATE

    public void ActiveShield(){

        if(Stats.instance.CURRENTMP <= 0){
            shield.SetActive(false);
        }else{
            shield.SetActive(true);
        }
        
        ControllerMPShield();
    }

    public void ControllerMPShield(){

        if(shield.activeSelf == true && Stats.instance.CURRENTMP > 0){
            Stats.instance.CURRENTMP -= Time.deltaTime;

        }

    }

    public void DesactiveShield(){

        shield.SetActive(false);

    }

    public void effectSword1(){

        Vector3 Scale;
        Vector3 direction;
        Quaternion rotation;

        if (position.transform.localScale.y == -1f){
            direction = new Vector3(1f,0,0); // derecha
            Scale = new Vector3(-1.5f,-1.5f,-1.5f);
            rotation = Quaternion.Euler(202f,-160f,16f);
            
            
        }else{
            direction = new Vector3(-1f,0,0); // izquierda
            Scale = new Vector3(1.5f,1.5f,1.5f);
            
            rotation = Quaternion.Euler(180f,-150f,-30f);
        } 
        
        GameObject effect1 = EffectSowrdPool.instance.requestEffectSword1();
        effect1.transform.position = transform.position + direction ;
        effect1.transform.localScale = Scale;
        effect1.transform.rotation = rotation;
        
    }

    public void effectSword2(){

        Vector3 Scale;
        Vector3 direction;
        Vector3 flipx;
        if (position.transform.localScale.y == -1f){
            direction = new Vector3(1f,0,0); // derecha
            Scale = new Vector3(-1.5f,-1.5f,-1.5f);
            flipx = new Vector3(0f,0f,1f);
            
        }else{
            direction = new Vector3(-1f,0,0); // izquierda
            Scale = new Vector3(1.5f,1.5f,1.5f);
            flipx = new Vector3(0f,0f,0f); 
        } 

        GameObject effect2 = EffectSowrdPool.instance.requestEffectSword2();
        effect2.transform.position = transform.position + direction;
        effect2.transform.localScale = Scale;
        
    }

    public void effectSword3(){

        Vector3 Scale;
        Vector3 direction;
        if (position.transform.localScale.y == -1f){
            direction = new Vector3(1f,0,0); // derecha
            Scale = new Vector3(-1.5f,-1.5f,-1.5f);
            
            
        }else{
            direction = new Vector3(-1f,0,0); // izquierda
            Scale = new Vector3(1.5f,1.5f,1.5f);
        } 

        GameObject effect3 = EffectSowrdPool.instance.requestEffectSword3();
        effect3.transform.position = transform.position + direction;
        effect3.transform.localScale = Scale;

    }

    public void EffectSwiftMovHorizontal(){

        if(Stats.instance.CURRENTMP >= 3f){

            ActiveforceHorizontal();
            Quaternion direction;
            if (position.transform.localScale.y == -1f) direction = Quaternion.Euler(0,-90f,-90f);
            else direction = Quaternion.Euler(-180,-90f,-90f);

            GameObject SwiftHor = EffectSwiftMovPool.instance.requestEffect();
            SwiftHor.transform.position = transform.position;
            SwiftHor.transform.rotation = direction;

        }
        
        Stats.instance.CURRENTMP -= 3f;
    }


    // Attack Poison

    public void EffectAttackPoison(){

        Vector3 Scale;
        Scale = new Vector3(1.3f,1.3f,1.3f);

        if(Stats.instance.CURRENTMP >= 20f){

            Stats.instance.CURRENTMP -= 20f;
            GameObject effectPoison = AttackPoisonPool.instance.requestBullet();
            effectPoison.transform.position = transform.position;
            effectPoison.transform.localScale = Scale;

        }

    }

    public void ActiveAttackPoison(){

        animator.SetBool("AttackPoison",true);
        
    }

    public void DesactiveAttackPoison(){

        animator.SetBool("AttackPoison",false);

    }

    public void MagicAttackJoystick(){

        if(Stats.instance.CURRENTMP >= 1){

            Stats.instance.CURRENTMP -= Time.deltaTime;

            if(Time.time > lastShoot + 0.2f){
            
                animator.SetBool("MagicAttack", true);
                MagicAttack();
                lastShoot = Time.time;
            }
        }

    }

    public void MagicAttack(){

        Vector3 direction;
        Quaternion pos;
        if (position.transform.localScale.y == -1f){
            direction = Vector3.right;
            pos = Quaternion.Euler(0,90,-90);
        }else{
            direction = Vector3.left;
            pos = Quaternion.Euler(-180,90,-90);
        } 

        GameObject magic = bulletPooling.instance.requestBullet();
        magic.transform.position = transform.position;
        magic.transform.rotation = pos;
        magic.GetComponent<MagicAttack>().SetDirection(direction);
    }

    public void EffectNormalAttack(){

        GameObject effectAttack = EffectNormalAttackPool.instance.requestBullet();
        effectAttack.transform.position = transform.position;

    }

    public void Attack(){
        
        if(Input.GetKeyDown(KeyCode.E) && attack == false){

            attack = true;
            animator.SetTrigger(""+combo);
            
        }

    }

    public void AttackJoystick(){

        CameraZoom.instance.ZoomActive = true;

        if(attack == false){

            attack = true;
            animator.SetTrigger(""+combo);
            
        }

    }

    public void JumpJoystick(){

        if(Grounded){
            Jump();

        }else if (doubleJump){

            rb.velocity = Vector2.zero;
            Jump();
            doubleJump = false;

        }

    }
    /*
    public void SmokeJoystick(){

        if(smoke == false){
            gameObject.SetActive(false);
            hollowSmoke.SetActive(true);
            smoke = true;
            hollowSmoke.transform.position = transform.position;
        }

    }
    */
    public void Start_Attack(){
        
        attack = false;

        if(combo<3){
            combo = combo + 1;
        }else {
            combo = 0;
        }

    }

    public void End_Attack(){
        
        attack = false;
        combo = 0;
        
    }

    public void Hit(float damage){

        // Efecto ralentizar al recibir un ataque enemigo
        int random = Random.Range(1,10);

        if(random <= 3){
            CameraScripts.instance.TimeSlow(0.05f);
        }
        
        
        // calculo de dano recibido (DMG - DEF)
        damage = damage - Stats.instance.DEF;

        if(damage < 0){
            damage = 1;
        }
        
        Stats.instance.CURRENTHP -= damage;

        // Valida si el personaje perdio toda su vida para transportarlo al ultimo punto de guardado
        if(Stats.instance.CURRENTHP <= 0){
            
            gameObject.SetActive(false);
            LevelManager.instance.RespawnPlayer();
        }

        // Effect Damage
        effectTakeDamage.SetActive(true);
        animator.SetBool("TakeDamage", true);
        
        //Text Damage
        GameObject textGo = TextDamagePool.instance.requesText();
        textGo.transform.position = transform.position + new Vector3(0,1f,0);
        textGo.GetComponent<TextMeshPro>().SetText("-" + damage);

        //effect damage 

        GameObject effectDamage =  effectPoolDamage.instance.requestBullet();
        effectDamage.transform.position = transform.position;
        
    }

    public void SlideDownWalkOn(){
        OnSlideWalk = true;

        if(OnStandUpWalk == false){
            
            animator.SetBool("SlideDownOn",true);
            rb.velocity = new Vector2(0,-1f);
            
        }else{
            SlideDownWalkOff();
        }
        
    }

    public void HoldOnWalkOn(){

        animator.SetBool("HoldOnWalk",true);
        OnStandUpWalk = true;
        rb.velocity = Vector2.zero;

    }

    public void HoldOnWalkOff(){
        animator.SetBool("HoldOnWalk",false);
        OnStandUpWalk = false;
    }
    public void SlideDownWalkOff(){
        animator.SetBool("SlideDownOn",false);
        OnSlideWalk = false;
        
    }

    
    private void Jump(){

        if(OnSlideWalk == false ){

            rb.AddForce(Vector2.up * JumpForce);

        }else if(OnSlideWalk == true){
            
            //rb.velocity = new Vector2(rb.velocity.x,10f);
            if(direccion == 1){
                
                rb.AddForce(((Vector2.left * 25f) + (Vector2.up * 3f)) * 200f);
            }else if(direccion == -1){
                rb.AddForce(((Vector2.right * 25f) + (Vector2.up * 3f)) * 200f);
                
            }
            
        }

        GameObject ExplosionSmoke = ExplosionSmokePool.instance.requestBullet();
        ExplosionSmoke.transform.position =  transform.position + new Vector3(0,-1f,0);
        
    }

    public void JumpBack(){

        if(forceToBack == true){
            
            timeToBack -= Time.deltaTime;

            if(direccion == 1){
                rb.AddForce((Vector2.left) * 500f);
                rb.AddForce((Vector2.up) * 25f);
            }

            if(direccion == -1){
                rb.AddForce((Vector2.right) * 500f);
                rb.AddForce((Vector2.up) * 25f);
            }
            
            

            if(timeToBack < 0){
                forceToBack = false;
                timeToBack = 0.2f;
            }
        }
        
    }

    public void activateJumpBack(){
        forceToBack = true;
    }

    IEnumerator CountHorizontal(){
        Horizontal = 0;
        yield return new WaitForSeconds(0.5f);

    }

    public void MoveSpeed(){

        if(force == true){

            time -= Time.deltaTime;

            if(position.transform.localScale.y == -1f){
                rb.AddForce(Vector2.right * moveForce);
            }else if(position.transform.localScale.y == 1f){
                rb.AddForce(Vector2.left * moveForce);
            }

            if(time < 0){
                force = false;
                time = 0.2f;
            }
        }

    }

    public void EffectExplosionSmoke(){

        Vector3 direction;
        if (position.transform.localScale.y == -1f) direction = new Vector3(-1f,0,0);
        else direction = new Vector3(1f,0,0);


        GameObject ExplosionSmoke = ExplosionSmokePool.instance.requestBullet();
        ExplosionSmoke.transform.position = transform.position + direction;
    }

    public void ForceHorizontal(){

        if(forceHorizontal == true){

            timeForce -= Time.deltaTime;

            if(position.transform.localScale.y == -1f){
                
                rb.AddForce(Vector2.right * 700f);
                //rb.velocity = new Vector2(1 * 20f, rb.velocity.y);
                 
            }else if(position.transform.localScale.y == 1f){
                
                //rb.velocity = new Vector2(-1 * 20f, rb.velocity.y);
                rb.AddForce(Vector2.left * 700f);  
                
            }

            if(timeForce < 0){
                forceHorizontal = false;
                timeForce = 0.3f;
                
            }
        }

    }

    public void MoveSpeedRevert(){

        if(forceRevert == true){

            time -= Time.deltaTime;

            if(position.transform.localScale.y == -1f){
                rb.AddForce(Vector2.left * moveForce);
            }else if(position.transform.localScale.y == 1f){
                rb.AddForce(Vector2.right * moveForce);
            }

            if(time < 0){
                forceRevert = false;
                time = 0.2f;
            }
        }

    }

    public void ActiveSlowDownTime(){

        CameraScripts.instance.SlowDownTime();
    }

    public void DesactiveSlowDownTime(){

        CameraScripts.instance.ResetTime();
    }
    public void ActiveforceHorizontal(){
        forceHorizontal = true;
    }
    public void StartForceRevert(){
        forceRevert = true;
    }
    public void StartForce(){
        force = true;
    }
    public void EndTakeDamage(){
        animator.SetBool("TakeDamage", false);
    }

    public void EndMagicAttack(){
        animator.SetBool("MagicAttack", false);
    }

    private void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.tag == "Platform"){

            transform.parent = other.transform;

        }

        if(other.gameObject.tag == "checkpoint"){
            Debug.Log("checkpoint");
        }

    }

  

    private void OnCollisionExit2D(Collision2D other){

        if(other.gameObject.tag == "Platform"){

            transform.parent = null;

        }

    }

}

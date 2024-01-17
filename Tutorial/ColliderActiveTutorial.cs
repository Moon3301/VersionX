using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderActiveTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public float typeTutorial;

    public TextMeshProUGUI Text;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player"){

            if(typeTutorial == 1){
                TutorialController.instance.Tutorial_jump = true;
                Text.SetText("Para saltar presiona el siguiente boton .... Tambien puedes ejecutar un doble salto si presionas dos veces -->");
                
                gameObject.SetActive(false);
            }

            if(typeTutorial == 2){
                TutorialController.instance.Tutorial_attack = true;
                Text.SetText("Para atacar presiona repetidamente el boton -->");
                
                gameObject.SetActive(false);
            }

            if(typeTutorial == 5){
                Text.SetText("Para treparse por las paredes, salta hacia ella .... Para subir manten presionado el boton dercho y presiona saltar");
                gameObject.SetActive(false);
            }

            if(typeTutorial == 3){
                TutorialController.instance.Tutorial_magicAttack = true;
                Text.SetText("Para lanzar proyectiles a un enemigo presiona el boton ... Tambien puedes cambiar esta habilidad recogiendo las diferentes cajas en el mapa");
                gameObject.SetActive(false);
            }            

            if(typeTutorial == 4){
                TutorialController.instance.Tutorial_velocity = true;
                Text.SetText("Para no recibir dano de las espinas ejecuta un movimiento con fuerza en horizontal y saltando al mismo tiempo -->");
                gameObject.SetActive(false);
            }

            if(typeTutorial == 6){
                TutorialController.instance.Tutorial_AttackDown = true;
                Text.SetText("Cuando existen muchos enemigos cerca puedes usar un ataque de area. Para ejecutarlo debes saltar y presionar el siguiente boton -- >");
                gameObject.SetActive(false);
            }

        }
      
    }

}

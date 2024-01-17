using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparring : MonoBehaviour
{
    // Start is called before the first frame update
    public static Sparring instance;
    public GameObject SpriteTimeSkip;



    void Start()
    {
        SpriteTimeSkip.SetActive(false);
        
    }
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Shield.instance.EffectSparring == true){

            StartCoroutine(CountActiveSparring());
        }
        */
        
    }

    public Vector2 ActiveSparring(){
    
        // Activa el sprite con aluminacion baja para presionar la direccion del efecto sparring
        
        
        // Activa la ralentizacion del tiempo

        // Verificar si hay toques (pulsaciones) en la pantalla
        if (Input.touchCount > 0)
        {
            // Solo consideramos el primer toque en este caso (índice 0)
            Touch touch = Input.GetTouch(0);

            // Verificar si el toque es de tipo "Began" (comenzó)
            if (touch.phase == TouchPhase.Began)
            {
                
                return touch.position;

                // Aquí puedes poner el código que se ejecutará cuando se detecte una pulsación
                // Por ejemplo, puedes llamar a una función para manejar la interacción del usuario
                // Ejemplo: MiFuncionDeInteraccion();
            }
        }


        Vector3 obj;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = player.transform.position.x - transform.position.x;

        if(distance > 0) obj = Vector3.right;
        else obj = Vector3.left;

        return obj;
    }

    IEnumerator CountActiveSparring(){
        yield return new WaitForSeconds(0.5f);
        Shield.instance.EffectSparring = false;
    }
}

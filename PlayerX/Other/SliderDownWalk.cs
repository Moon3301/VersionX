using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderDownWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Deslizando;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerW.instance.SlideDownWalkOn();
            Deslizando = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerW.instance.SlideDownWalkOn();
            Deslizando = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            PlayerW.instance.SlideDownWalkOff();
        }
    }
}

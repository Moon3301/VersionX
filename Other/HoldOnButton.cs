using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HoldOnButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    public UnityEvent OnHold;
    public UnityEvent OffHold;

    public UnityEvent ClickBtn;
    bool OnPressed;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OnPressed){
            OnHold.Invoke();
        }

        if(!OnPressed){
            OffHold.Invoke();
        }

        
        
    }

    public void OnPointerDown( PointerEventData eventData )
    {
        OnPressed = true;
    }

    public void OnPointerUp( PointerEventData eventData )
    {
        OnPressed = false;
    }

    
}

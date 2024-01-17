using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DetectBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update

    public bool ActiveJump;
    public bool ActiveAttack;

    public Button btnJump;

    public UnityEvent OnHold;
    public UnityEvent OffHold;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnPointerDown( PointerEventData eventData )
    {
        
    }

    public void OnPointerUp( PointerEventData eventData )
    {
        
    }
}

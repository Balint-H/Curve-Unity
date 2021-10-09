using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressDetectButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool is_Touched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        is_Touched = true;
        gameObject.GetComponentInParent<Animator>().Play("Pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        is_Touched = false;
        gameObject.GetComponentInParent<Animator>().Play("Released");
    }
}

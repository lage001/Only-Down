using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IsUsingVK : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isUsingVertualKey = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isUsingVertualKey = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isUsingVertualKey = false;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Close : MonoBehaviour,IPointerClickHandler
{   
    public bool isTimeRun;
    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.gameObject.SetActive(false);
        if (isTimeRun)
        {
            Time.timeScale = 1;
        }
    }

}

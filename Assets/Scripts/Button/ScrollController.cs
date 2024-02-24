using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ScrollController : MonoBehaviour
{
    ScrollRect scrollrect;
    public float target;
    public float scrollPos;
    public float smoothing = 10;
    void Start()
    {
        scrollrect = GetComponent<ScrollRect>();
        scrollPos = 1;
    }

    void FixedUpdate()
    {
        target = (scrollPos % 4+ 4)%4/ 3;
        scrollrect.horizontalNormalizedPosition = Mathf.Lerp(scrollrect.horizontalNormalizedPosition, target, Time.deltaTime * smoothing);
    }
}

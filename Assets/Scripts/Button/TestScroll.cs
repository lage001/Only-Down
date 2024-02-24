using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScroll : MonoBehaviour
{
    // Start is called before the first frame update
    ScrollRect scrollRect;
    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }
    void Update()
    {
        print(scrollRect.horizontalNormalizedPosition);
    }
}

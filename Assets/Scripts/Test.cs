using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    delegate void GetNumber();
    List<GetNumber> getNumbers = new List<GetNumber>();
    BasePanel[] basePanels;
    private void Awake()
    {
    }
}

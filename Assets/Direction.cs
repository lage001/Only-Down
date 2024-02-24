using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public IsUsingVK RVK;
    public IsUsingVK LVK;

    public float xVelocity = 0;
    public bool isUsingVirtualKey;
    private void Update()
    {
        isUsingVirtualKey = RVK.isUsingVertualKey | LVK.isUsingVertualKey;
        if (isUsingVirtualKey)
        {
            if (RVK.isUsingVertualKey)
            {
                xVelocity = 1;
            }
            if (LVK.isUsingVertualKey)
            {
                xVelocity = -1;
            }
        }
        else
        {
            xVelocity = 0;
        }
    }
}

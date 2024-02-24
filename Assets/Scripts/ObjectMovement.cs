using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    float EndPos = 12.22f;

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        Finish();
    }
    
    void Finish()
    {
        if (transform.position.y > EndPos)
        {
            Destroy(gameObject);
        }
    }
}

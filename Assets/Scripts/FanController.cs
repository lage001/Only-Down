using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    Animator anim;
    public float eps;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        anim.speed = 1;
        anim.Play("FanPlatmorm");
        float force = eps * (transform.position.y + 3 - collision.transform.position.y);
        
        Rigidbody2D rig = collision.GetComponent<Rigidbody2D>();
        Vector2 resistance;
        if (collision.transform.position.y - transform.position.y > 2.5f)
        {
            resistance = Vector2.zero;
        }
        else
        {
            resistance = rig.velocity;
        }
        rig.AddForce(new Vector2(0, force) - resistance);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.speed = 0;
    }
}

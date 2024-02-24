using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    float xVelocity;
    public float moveSpeed;

    Rigidbody2D rig;
    Animator anim;
    ControlPanel controlPanel;

    public bool isDead;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        controlPanel = GameManager.Instance.controlPanel;
        isDead = false;
    }


    void Update()
    {
        Move();
    }
    void Move()
    {   
        if (controlPanel.isUsingVKR | controlPanel.isUsingVKL)
        {
            int a = controlPanel.isUsingVKR ? 1 : 0;
            int b = controlPanel.isUsingVKL ? -1: 0;
            xVelocity = a + b;
        }
        else
        {
            xVelocity = Input.GetAxisRaw("Horizontal");
        }
        rig.velocity = new Vector2(xVelocity * moveSpeed, rig.velocity.y);
        anim.SetFloat("xSpeed", Mathf.Abs(xVelocity));
        if (xVelocity != 0)
        {
            transform.localScale = new Vector3(xVelocity, 1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isOnPlatform", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isOnPlatform", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (collision.CompareTag("spike"))
        {
            anim.SetTrigger("dead");
            isDead = true;
        }
    }
}

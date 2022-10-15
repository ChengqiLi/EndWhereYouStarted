using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerScript playerScript;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<PlayerScript>();
    }
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));//注意速度可能是负数
        anim.SetBool("jump", playerScript.isJumping);
        anim.SetBool("ground", playerScript.isGround);
        anim.SetFloat("velocityY", rb.velocity.y);
    }
}

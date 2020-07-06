using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Canvas gameOver;

    private gameMaster gm;
    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer sprite;
    public CircleCollider2D foot;
    public LayerMask ground;

    public float runSpeed = 10;
    public float jumpForce = 200;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    void Update()
    {
        GetForwardInput();
        GetJumpInput();
    }

    private void GetJumpInput()
    {
        if (Input.GetButtonDown("Jump") && foot.IsTouchingLayers(ground))
        {
            body.AddForce(Vector2.up * jumpForce);
        }

        animator.SetBool("IsOnGrond", foot.IsTouchingLayers(ground));
    }

    private void GetForwardInput()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, body.velocity.y);
        animator.SetFloat("xSpeed", Mathf.Abs(body.velocity.x));
        if (!sprite.flipX && body.velocity.x < 0)
        {
            sprite.flipX = true;
        }
        else if (sprite.flipX && body.velocity.x > 0)
        {
            sprite.flipX = false;
        }
    }

    [Obsolete]
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pontos"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
        }
        else if (col.CompareTag("Pirata"))
        {
            Destroy(col.gameObject);
            gm.points = gm.points / 2;
        }
        else if (col.CompareTag("Sabedoria10"))
        {
            Destroy(col.gameObject);
            gm.points = gm.points * 10;
        }
        else if (col.CompareTag("Sabedoria"))
        {
            Destroy(col.gameObject);
            gm.points = gm.points * 2;
        }
        else if (col.CompareTag("Dead"))
        {
            gameOver.enabled = true;
        }
    }

}

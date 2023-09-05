using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private float movespeed;
    private Vector2 moveDirection;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveDirection.x, moveDirection.y).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * movespeed * Time.fixedDeltaTime);
        UpdateAnimState();
        
    }

    private void UpdateAnimState()
    {
        if (moveDirection.x > 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
        }
        else if (moveDirection.x < 0f)
        {
            anim.SetBool("isRunning", true);            
            sprite.flipX = true;
        }
        else if (moveDirection.y > 0f)
        {
            anim.SetBool("isRunning", true);           

        }
        else if (moveDirection.y < 0f)
        {
            anim.SetBool("isRunning", true);            
        }
        else
        {
            anim.SetBool("isRunning", false);            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController2 : MonoBehaviour
{
    public float jumpforce = 5.0f;
    public float speed = 3.0f;
    public float moveDirection;

    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D _rigidBody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if(_rigidBody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        _rigidBody2D.velocity = new Vector2(speed * moveDirection, _rigidBody2D.velocity.y);
        if (jump ==true)
        {
            _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, jumpforce);
            jump = false;
        }
    }

    private void Update()
    {
        if (grounded == true && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection =-1;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);

            }
        }
        else if (grounded == true)
        {
            moveDirection = 0;
            anim.SetFloat("speed", 0);

        }
        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="zemin")
        {
            anim.SetBool("grounded", true);
            grounded = true;
        }
        
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed =3.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera;
    private SpriteRenderer _spriteRenderer;
    

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();// caching
        _animator = GetComponent<Animator>();
        charPos = transform.position;
        

    }

    private void FixedUpdate()
    {
        //r2d.velocity = new Vector2(speed, 0f);
       
    }

    void Update()
    {
        
        charPos = new Vector3(charPos.x+(Input.GetAxis("Horizontal") * speed *Time.deltaTime),charPos.y);
        transform.position = charPos;
        if (Input.GetAxis("Horizontal") == 0.0f) {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", speed);
        }
        
        if(Input.GetAxis("Horizontal")> 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
        

    }

    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);

    }
}

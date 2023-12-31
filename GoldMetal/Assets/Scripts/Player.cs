using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;

    public float Speed;
    public Scanner scanner;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Animator anim;

    private void Awake()
    {
        rigid  = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }
    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // ��ġ �̵�
        Vector2 nextVec = inputVec.normalized * Time.deltaTime*Speed;
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x!=0)
        {
            spriteRenderer.flipX = inputVec.x<0;
        }
    }
}

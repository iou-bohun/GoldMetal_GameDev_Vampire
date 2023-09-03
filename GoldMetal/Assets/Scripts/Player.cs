using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public GameObject start;

    public float Speed;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Animator anim;

    private void Start()
    {
        Instantiate(start);
    }

    private void Awake()
    {
        rigid  = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // 위치 이동
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

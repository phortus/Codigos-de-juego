using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 5.0f;
    float jump = 10f;
    public Animator anim, animS;
    public int health = 3;
    internal static object position;


    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        animS = transform.GetChild(1).GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Atack();

    }
    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal > 0) transform.localScale = new Vector2(1, 1);
        if (moveHorizontal < 0) transform.localScale = new Vector2(-1, 1);
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            //rb.AddForce..
            rb.velocity = new Vector2(rb.velocity.x, jump);
            anim.SetTrigger("Jump");
        }
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        anim.SetFloat("Move", Mathf.Abs(moveHorizontal));
    }
    private void Atack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("atack");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("Damage");
        if (collision.gameObject.tag == "enemy") 
        { 
            Destroy(gameObject);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 8.0f;
    float jump = 15f;
    public Animator anim, animS;
    public  int health = 3;
    internal static object position;
    public GameObject[] corazones;



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
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");

        if (moveHorizontal > 0) transform.localScale = new Vector2(1, 1);
        if (moveHorizontal < 0) transform.localScale = new Vector2(-1, 1);
        //jump
        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
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
        if (CrossPlatformInputManager.GetButtonDown("Atack"))
        {
            anim.SetTrigger("atack");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy") 
        { 
            Destroy(gameObject);
        }
    }
    private void Vida()
    { 
        if (health < 1)
        {
            Destroy(corazones[0].gameObject);
            SceneManager.LoadScene("over");
        }
        if (health < 2)
        {
            Destroy(corazones[1].gameObject);
        }
         if (health < 3)
        {
            Destroy(corazones[2].gameObject);
        }
    }
    public void Damage()
    {
        health--;
        Vida();
    }
    
}
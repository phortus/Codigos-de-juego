using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float speed= 5f;
    Rigidbody2D rb;
    public Vector2 myPsoition;
    Animator anim;
    Vector2 lookDirection = new Vector2(1, 0);

    int maxHelth = 5;
    int currentHealt;
    bool isInvencible;
    float invencibleTimer;
    public GameObject bull;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealt = maxHelth;
        Debug.Log("La vida actual de ruby es: ");
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       myPsoition = new Vector2(horizontal, vertical) ;
       transform.position += myPsoition;

        if (horizontal == 0 || vertical == 0)
        {
            lookDirection.x = horizontal;
            lookDirection.y = vertical;
            lookDirection.Normalize();

        }
        anim.SetFloat("Look X", horizontal);
        anim.SetFloat("Look Y", vertical);
        anim.SetFloat("Speed", lookDirection.magnitude);
        if (isInvencible) 
        {
            invencibleTimer = invincibleTimer.deltaTime;
            if(isInvencibleTimer < 0)
            {
                isInvencible = false;
            }
        }
        if (Input.GetKeyDown(KeCode.Space))
        { 
           GameObject projectile Instantiate(bull, rb.position, new Vector2(0, 0.5f), Quaternion.identity);
            projectile.getComponent<Rigidbody2D>().AddFoce(lookDirection*15, 300);
            anim.SetTrigger("Launch");

        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + myPsoition * speed * Time.deltaTime);
    }
    void changeHealth(int amount) 
    {
        if(amount < 0)
           {
            if (isInvencible)
            {
                return;
            }
            isInvencible = true;
            invencibleTimer = 1.5f;

           }
        currentHealt += Mathf.Clamp(currentHealt+amount, 0, maxHelth);
        Debug.Log("La vida actual de ruby es: " + currentHealt);
        
    }
}

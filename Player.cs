using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] float speed = 5f;
    private Rigidbody2D rB;
    Vector2 myPosition;
    
    Animator anim;
    Vector2 lookDirection = new Vector2(1, 0);
    
    public string nextID = "0";

    int maxHealth = 5;
    int currentHealth;

    void changeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.LogError(currentHealth);
    }

    void FixedUpdate()
    {
        rB.MovePosition(rB.position + myPosition * speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        myPosition = new Vector2(horizontal, vertical);
        if (horizontal != 0 || vertical != 0)
        {
            lookDirection.x = horizontal;
            lookDirection.y = vertical;
            lookDirection.Normalize();
        }
        anim.SetFloat("LookX", lookDirection.x);
        anim.SetFloat("LookY", lookDirection.y);
        anim.SetFloat("speed", myPosition.magnitude);
    }

}
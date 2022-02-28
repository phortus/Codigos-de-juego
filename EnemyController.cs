using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbodu2D rb;
    float speed;
    public bool vertical;
    float timer;
    float changeTime = 3f;
    int direction = 1;

    Animator anim;
    bool botFixed;

    public ParticleSystem smoke;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }
    private void FixedUpdate() 
    {
        if(!isFixed)
        {
            anim.SetFloat
        }
        vector2 position = rb.position;
        if (vertical)
        {
            position.y += speed * Time.deltaTime * direction;
        }
        else 
        {
            position.x += speed * Time.deltaTime * direction;
        }
        rb.MoverPosition(position);
    }
    // Update is called once per frame
    void Update()
    {
        timer -= timer.deltaTime;
        if (timer < 0) 
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    private void OnCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<RubyController>().changeHealth(-2);
        }
    }
    public void FiX()
    {
        isFixed = true;
        rb.simlated = false;
        anim.SetTrigger("Fiexd");
        smoke.Stop();
    }
}

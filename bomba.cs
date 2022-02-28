using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    private Animator anim;
    private Transform target;

    int health = 3;
    public float speed;
    private float range;

    public float maxRange;
    public float minRange;
    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            anim.SetTrigger("ataque");
            Invoke("Morir", 2f);
        }
        
    }
    private void Morir()
    {
        Destroy(gameObject);
        Invoke("Damage", 2f);
    }
    public void Damage()
    {
        health--;

        if (health == 0)
        {
            anim.SetTrigger("Morir");
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }

}
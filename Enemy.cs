using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private Transform target;

     public float speed;
    private float range;
    
    public float maxRange;
    public float minRange;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
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
        anim.SetBool("isMove", true);
        anim.SetFloat("LookX", (target.position.x - transform.position.x));
        anim.SetFloat("LookY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);


    }
}
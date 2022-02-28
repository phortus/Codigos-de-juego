using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platdestruida : MonoBehaviour
{

    public float fallDelay = 1f;
    public float respawnDelay = 6f;
    //public bool falling;

    private Rigidbody2D rb2D;
    private EdgeCollider2D pc2D;
    //private Animator anim;
    private Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pc2D = GetComponent<EdgeCollider2D>();
        // anim = GetComponent<Animator>();
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //  anim.SetBool("Falling", falling);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // falling = true;
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
            //  Invoke("Reset", fallDelay + respawnDelay);

        }
    }

    void Fall()
    {
        rb2D.isKinematic = false;
        pc2D.isTrigger = true;
    }

    void Reset()
    {
        //falling = false;
    }

    void Respawn()
    {
        transform.position = start;
        rb2D.isKinematic = true;
        rb2D.velocity = Vector3.zero;
        pc2D.isTrigger = false;
    }
}

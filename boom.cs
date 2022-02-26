using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public Animator ani;
    private void Start()
    {
        ani = GetComponent < Animator >();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            ani.SetTrigger("ataque");
        }
    }
}

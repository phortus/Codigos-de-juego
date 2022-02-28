using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sistemadepuntos : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            SceneManager.LoadScene("Fin");
        }
    }
}

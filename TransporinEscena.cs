using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporinEscena : MonoBehaviour
{
    public GameObject ObjectTransportar;
    public Vector2 TeleportPos;
    public GameObject ObjetoDestino;
    // Start is called before the first frame update
    void Start()
    {
        TeleportPos = ObjetoDestino.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        ObjectTransportar.transform.position = TeleportPos;
    }
}

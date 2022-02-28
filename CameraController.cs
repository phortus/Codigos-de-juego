using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector2 minCamLimit, maxCamLimit;
    public float camTime;

    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Sigue a target, en este caso el gameObject "player", SmoothDamp sirve para darle un pequeño retraso de seguimiento a la camara, la variable camTime guarda un valor float
        //que se ve transformado en tiempo.

        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, camTime);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, camTime);

        //Clamp sirve para recortar, al aplicarselo a un vector conseguiremos que la camara solo pueda moverse en un área reducida, en este caso el área del mapa.

        transform.position = new Vector3(Mathf.Clamp(posX, minCamLimit.x, maxCamLimit.x),
                                         Mathf.Clamp(posY, minCamLimit.y, maxCamLimit.y),
                                         transform.position.z);
    }
}
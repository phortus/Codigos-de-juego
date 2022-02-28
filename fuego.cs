using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuego : MonoBehaviour
{
    public float bS;
    public float spawnTime;
    public GameObject spawnner;
    public GameObject bulletPrefab;
    public float counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        counter += Time.deltaTime;

        if (counter > spawnTime)
        {
            GameObject Planta = (GameObject)Instantiate(bulletPrefab, spawnner.transform, true);
            Planta.GetComponent<Rigidbody2D>().velocity = new Vector2(bS, Planta.GetComponent<Rigidbody2D>().velocity.y);
            counter = 0;
            
        }
    }
}

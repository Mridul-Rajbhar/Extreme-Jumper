using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{

    public float force;
    public GameObject cloudPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instantiateClouds();
    }

    void instantiateClouds()
    {
        if(gameObject.transform.position.y < -9f)
        {
            Instantiate(cloudPrefabs, new Vector3(0f,10f,0f), transform.rotation);
            Destroy(gameObject);
        }
        gameObject.transform.Translate(Vector3.down*force*Time.deltaTime);
    }
}

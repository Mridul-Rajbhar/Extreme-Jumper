using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabCoin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instantiateCoins();
    }
    void instantiateCoins()
    {
        if (gameObject.transform.position.y < -4.94f)
        {
            var clone = Instantiate(prefabCoin, new Vector3(Random.Range(-2.07f, 2.35f), Random.Range(-3.925f,4f), 0f), transform.rotation);
            clone.name = "coin";
            Destroy(gameObject);
           
        }
    }
}

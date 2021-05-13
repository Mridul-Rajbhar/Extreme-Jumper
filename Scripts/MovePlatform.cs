using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject[] platforms = new GameObject[3];

    static private int score = 0;
    private float min,max;
    //public GameObject baseDestroyer;
    static public float force = -0.7f;
    static public float posX = -0.8289944f;
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {

        instantiatePaltforms();  
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("collsion occured");
            collision.collider.transform.SetParent(transform);
        }
       
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("collsion exit");
            collision.collider.transform.SetParent(null);
        }
    }
    void instantiate(int position, float min , float max)
    {
        posX = Random.Range(min, max);


        var clone = Instantiate(platforms[position],new Vector3(posX, 6.06f, 0),transform.rotation);
        clone.name = "Clone";
        Destroy(gameObject);
        score++;
        if (score % 25 == 0)
            force -= 0.2f;
    }
    void instantiatePaltforms()
    {

       transform.position = new Vector3(transform.position.x, transform.position.y + force*Time.deltaTime);
        if (gameObject.transform.position.y <= -3.982f)
        {
            float left = 2 + posX;
            float right = 2 - posX;
            int x = Random.Range(0, platforms.Length);
            if (right >= left)
            {
                min = posX + (platforms[x].transform.localScale.x / 2);
                max = posX + (gameObject.transform.localScale.x / 2) + 0.5f + (platforms[x].transform.localScale.x / 2);
                instantiate(x, min, max);
            }
            else
            {
                max = posX - (platforms[x].transform.localScale.x / 2);
                min = posX - (gameObject.transform.localScale.x / 2) - 0.5f - (platforms[x].transform.localScale.x / 2);
                instantiate(x, min, max);
            }
        }
    }

}

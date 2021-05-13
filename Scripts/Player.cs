using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Rigidbody2D myBody;
    public float speed = 2f;
    public float jumpForce = 5f;

    private bool PlayerCanJump;//we can jump or not
    private bool moveLeft;//in which direction to move
    private bool dontMove;//we are moving or not

    [SerializeField]
    static public int score = 0;

    private void Start()
    {
        PlayerCanJump = true;
        dontMove = true;
        playerAnimation = GetComponent<PlayerAnimation>();
        myBody = GetComponent<Rigidbody2D>();   
    }
    // Update is called once per frame
    void Update()
    {
        HandleMoving();
        if (gameObject.transform.position.y < -3.9f)
        {
            Destroy(gameObject);
        }
    }
    public void HandleMoving()
    {
        if(dontMove)
        {
            StopMoving();
        }
        else
        {
            if(moveLeft)
            {
                MoveLeft();
            }
            else if(!moveLeft)
            {
                MoveRight();
            }
        }
    }

    public void AllowMovement(bool movement)
    {
        dontMove = false;
        moveLeft = movement;
    }
    public void DontAllowMove()
    {
        dontMove = true;
    }
    public void Jump()
    {
        if (PlayerCanJump)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
        }
            
    }
    public void StopMoving()
    {
        playerAnimation.PlayerStop();
        myBody.velocity = new Vector2(0f,myBody.velocity.y);
    }
    public void MoveLeft()
    {
        myBody.velocity = new Vector2(-speed,myBody.velocity.y);
        playerAnimation.PlayerWalk(true, true);
    }
    public void MoveRight()
    {
        myBody.velocity = new Vector2(speed,myBody.velocity.y);
        playerAnimation.PlayerWalk(true, false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "P2" || collision.gameObject.tag == "P1" || collision.gameObject.tag=="platform2" || collision.gameObject.tag == "platform3" || collision.gameObject.tag == "platform4")
        {

            PlayerCanJump = true;
            
            //this.transform.parent = collision.transform;
        }
        if(collision.gameObject.tag == "coins")
        {
            score+=3;
            Instantiate(collision.gameObject, new Vector3(Random.Range(-2f, 2f), Random.Range(-3.921f, 12.14f), 0), transform.rotation);
            Destroy(collision.gameObject);
        }
        //Debug.Log(score);
    }

   void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "P2" || collision.gameObject.tag =="P1"|| collision.gameObject.tag == "platform3"|| collision.gameObject.tag == "platform4"|| collision.gameObject.tag == "TwoPlatforms")
        {
            //Debug.Log("false");
            //Debug.Log(collision.gameObject.tag);
            PlayerCanJump = false;
            //this.transform.parent = null;
        }
    }
}

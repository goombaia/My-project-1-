using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public int  playerSpeed=10;
    private bool   facingRight= false;
    public int playerJumpPower= 1250;
    private float moveX;

    void Update()
    {
        playerMove();   
    }
    void playerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
        //animations
        //player diraction
        if (moveX < 0.0f && facingRight == false)
        {
            flipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            flipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX*playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void jump()
    {
        //jumping code
        GetComponent<Rigidbody2D> ().AddForce(Vector2.up*playerJumpPower);
    }
    void flipPlayer()
    {
        facingRight = !facingRight;
        Vector2 locaclScale= gameObject.transform.localScale;
        locaclScale.x *= -1;
        transform.localScale = locaclScale;
    }
}

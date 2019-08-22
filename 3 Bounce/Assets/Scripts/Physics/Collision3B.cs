using UnityEngine;

public class Collision3B  : MonoBehaviour
{
    //attributes
    public Sprite ball3, ball2, ball1, ball0;
   

    //Checks if ball collided with wall, lowers ball value by 1 if they collided with wall
    void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == ball3 && col.gameObject.tag == "Wall") //if ball3 collides with a wall, make it ball2
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ball2;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == ball2 && (col.gameObject.tag == "Wall" || col.gameObject.tag == "Roof")) //if ball2 collides with a wall or roof, make it ball1
        { 
            gameObject.GetComponent<SpriteRenderer>().sprite = ball1;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == ball1 && (col.gameObject.tag == "Wall" || col.gameObject.tag == "Roof")) //if ball1 collides with a wall or roof, make it ball0
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ball0;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == ball0 && (col.gameObject.tag == "Wall" || col.gameObject.tag == "Roof")) //if ball0 collides with a wall or roof, remove a heart,  destroy the ball, remove one from current ballcount
        {
            Health3B.health -= 1;
            Balls3B.ballCollision = true;
            Destroy(gameObject);
            Balls3B.ballCount--;
        }
    }
}


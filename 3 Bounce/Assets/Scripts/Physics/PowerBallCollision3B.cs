using UnityEngine;

public class PowerBallCollision3B : MonoBehaviour
{
   
    private int counter = 0;

    // handles the collision of powerballs (skullballs and heartballs)
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Roof") //add one the the collision counter if the powerball collided with a wall or roof
        {
            counter++;
        }
        if (counter >= 4) //if the ball collided 4 times (1 roof and 3 walls), destroy the powerball, remove 1 from current ballcount
        {
            Balls3B.ballCollision = true;
            Destroy(gameObject);
            Balls3B.ballCount--;
            counter = 0;
            if(gameObject.tag == "HeartBall") //a heartball is no longer in play
            {
                Balls3B.heartBallInPlay = false;
            }
          
        }

    }
}

     
 


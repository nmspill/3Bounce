using System.Collections.Generic;
using UnityEngine;

public class BallsTouchControls3B : MonoBehaviour
{

    //Attributes
    public GameObject Ball, HeartBall, SkullBall, LightSkullBall, DarkSkullBall;
    public Transform BallSpawn1, BallSpawn2, BallSpawn3, BallSpawn4;
    private CircleCollider2D CircCollider;
    public List<GameObject> ballList;
    private Rigidbody2D rb2D;
    AudioSource Audio;
    public AudioClip pop;
    private float timer = 0f;
    private float spawnTime;
    public static int ballCount;
    private int maxBallCount;
    public static bool heartBallInPlay, ballCollision;
    private bool playAfterDeath;



    // Start is called before the first frame update
    void Start()
    {
        playAfterDeath = true;
        SetSkullBallColor();
        maxBallCount = 1;
        ballCount = 0;
        heartBallInPlay = false;
        Audio = GetComponent<AudioSource>();
        ballCollision = false;
    }

    void FixedUpdate()
    {
        PopOnCollision();
        SpawnBall();
        if (IsTouch())
        {
            CheckTouch(GetTouchPosition());
        }
    }

   
    // Instantiates a ball
    private void AddBall()
    {
        int spawnNum = Random.Range(0, 4); //Randomly choses a spawnpoint
        Transform[] ballSpawnArr = { BallSpawn1, BallSpawn2, BallSpawn3, BallSpawn4 }; //Array of spawnpoints
        ballList.Add(Instantiate(Ball, ballSpawnArr[spawnNum].position, ballSpawnArr[spawnNum].rotation)); //Instantiates the new ball
        AddForceToBall(); //Adds force to the new ball
        RemoveBall(); //Removes the new ball from the list of balls
        ballCount++; //Increases the current ballcount by 1


    }

    // Instantiates a skull ball
    private void AddSkullBall()
    {
        int spawnNum = Random.Range(0, 4); //Randomly choses a spawnpoint
        Transform[] ballSpawnArr = { BallSpawn1, BallSpawn2, BallSpawn3, BallSpawn4 }; //Array of spawnpoints
        ballList.Add(Instantiate(SkullBall, ballSpawnArr[spawnNum].position, ballSpawnArr[spawnNum].rotation));  //Instantiates the new ball
        AddForceToBall();  //Adds force to the new ball
        RemoveBall(); //Removes the new ball from the list of balls
        ballCount++; //Increases the current ballcount by 1

    }

    // Instantiates a skull ball
    private void AddHeartBall()
    {
        int spawnNum = Random.Range(0, 4); //Randomly choses a spawnpoint
        Transform[] ballSpawnArr = { BallSpawn1, BallSpawn2, BallSpawn3, BallSpawn4 }; //Array of spawnpoints
        ballList.Add(Instantiate(HeartBall, ballSpawnArr[spawnNum].position, ballSpawnArr[spawnNum].rotation));  //Instantiates the new ball
        AddForceToBall();  //Adds force to the new ball
        RemoveBall(); //Removes the new ball from the list of balls
        ballCount++; //Increases the current ballcount by 1
        heartBallInPlay = true; //Boolean that is true when a heartball is in play
    }

    // This method deals what ball gets spawned, how many balls will get spawned, and the time between ball spawns
    private void SpawnBall()
    {
        int skullSpawn = Random.Range(1, 11); //odds to be skull ball
        bool heartSpawn = CanHeartBallSpawn(); //boolean that determines if a heartball can be spawned or not
        timer += Time.deltaTime; //timer
        spawnTime = Random.Range(.5f, 3f); //spawn time range

        if (timer > spawnTime)
        {
            if (ballCount < maxBallCount) //checks if too many balls 
            {
                if (skullSpawn != 10 && !CanHeartBallSpawn()) //checks if skull ball 
                {
                    if (Health3B.health > 0) //checks if health > 0
                    {
                        AddBall(); //adds a ball
                        timer = 0; //resets timer
                    }
                }

                else if (skullSpawn == 10) //checks if skull ball
                {
                    if (Health3B.health > 0) //checks if health > 0
                    {
                        AddSkullBall(); //adds a skullball
                        timer = 0; //resets timer
                    }
                }

                else if (CanHeartBallSpawn())
                {
                    if (Health3B.health > 0) //checks if health > 0
                    {
                        AddHeartBall(); //adds a HeartBall
                        timer = 0; //resets timer
                    }
                }
            }
        }
    }

    //checks if a heart ball can spawn
    private bool CanHeartBallSpawn()
    {
        int heartSpawn = Random.Range(1, 11); //odds that a heartball is spawned
        if (Health3B.health < 3 && heartSpawn == 10 && !heartBallInPlay) //returns true if the player has less that 3 lives, a heartball was chosen, and a heartball is not in play 
        {
            return true;
        }
        return false;
    }

    //Increases the amount of balls that can spawn at once as the score increases
    private void Difficulty()
    {
        if (Score3B.scoreText >= 5) //sets the max ballcount to 2 if the score is 5 or more
        {
            maxBallCount = 2;
        }
        if (Score3B.scoreText >= 15) //sets the max ballcount to 3 if the score is 15 or more
        {
            maxBallCount = 3;
        }
        if (Score3B.scoreText >= 50) //sets the max ballcount to 4 if the score is 50 or more
        {
            maxBallCount = 4;
        }
        if (Score3B.scoreText >= 100) //sets the max ballcount to 5 if the score is 100 or more
        {
            maxBallCount = 5;
        }
    }

    // Removes a ball from the list
    public void RemoveBall()
    {
        ballList.Remove(ballList[0]);
    }

    // Determines balls movement and rotation
    private void AddForceToBall()
    {
        bool chooseThrust = (Random.value > 0.5f); // a random boolean
        float thrust;
        float rotationSpeed;
        if (chooseThrust)
        {
            thrust = 50f;
            rotationSpeed = 55f;
        }
        else
        {
            thrust = -50f;
            rotationSpeed = -55f;
        }

        rb2D = ballList[ballList.Count - 1].GetComponent<Rigidbody2D>();
        rb2D.AddForce(new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f)) * thrust); //Adds force to the new ball in a random direction
        rb2D.AddTorque(rotationSpeed); //adds torque to the new ball
    }

    // Returns true if the wall is touched
    private bool CheckWall(Vector2 touchPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);

        if (hit.collider.tag == "Wall") //returns true if the player touched on a wall
        {
            return true;
        }
        return false;
    }

    // Destroys the ball at the given vector2 position
    private void DestroyBall(Vector2 touchPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
        Destroy(hit.collider.gameObject); //destroys the ball that was touched
        ballCount--; //removes one from the current ball count
    }

    // Returns true if the screen is touched
    public static bool IsTouch()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                return true;
            }
        }
        return false;
    }

    // Gets the position the touch
    private Vector2 GetTouchPosition()
    {
        Vector2 touchPos = new Vector2(0f, 0f);
        Touch touch = Input.GetTouch(0);

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPos = touch.position;
        }

        return touchPos;
    }

    // Checks the position of the touch and destroys the ball if the ball is touched
    private void CheckTouch(Vector2 touchPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);

        if (hit.collider != null && (CheckWall(touchPos) == false))//checks if a ball was touched
        {

            if (Health3B.IsAlive()) //checks if the player is still alive
            {
                if (CheckIfSkullBall(touchPos)) //checks if a skullball was touched
                {
                    Health3B.health--;
                }
                else if (CheckIfHeartBall(touchPos)) //checks if a heartball was touched
                {
                    Health3B.health++;
                    heartBallInPlay = false;
                }
                else //a ball was touched
                {
                    Score3B.scoreText++;
                    PlayerPrefs.SetInt("GameScore", PlayerPrefs.GetInt("GameScore") + 1);
                    Difficulty(); //Increases the difficulty as score increases
                }

                if (PlayerPrefs.GetInt("Sound") == 0) //plays audio on the last ball touched if no lives remaining
                {
                    Audio.PlayOneShot(pop, 1F);
                }
                DestroyBall(touchPos); //destroys the ball that was touched
            }
        }

    }

    //Changes the Color of the SkullBall depending on if the game is in light or dark mode
    private void SetSkullBallColor()
    {
        if (PlayerPrefs.GetInt("DarkMode") == 1)
        {
            SkullBall = LightSkullBall;
        }
        else
        {
            SkullBall = DarkSkullBall;
        }
    }

    //Checks if a skull ball touched
    private bool CheckIfSkullBall(Vector2 touchPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
        if (hit.collider.tag == "SkullBall")
        {
            return true;
        }
        return false;
    }

    //Checks if a heart ball is touched
    private bool CheckIfHeartBall(Vector2 touchPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
        if (hit.collider.tag == "HeartBall")
        {
            return true;
        }
        return false;
    }

    //Plays pop sound when a ball is destroyed from colliding
    private void PopOnCollision()
    {
        if (ballCollision)
        {
            if (Health3B.IsAlive())
            {
                if (PlayerPrefs.GetInt("Sound") == 0)
                {
                    Audio.PlayOneShot(pop, 1F);
                    ballCollision = false;
                }
            }
            else if (!Health3B.IsAlive())
            {
                if (playAfterDeath)
                {
                    if (PlayerPrefs.GetInt("Sound") == 0)
                    {
                        Audio.PlayOneShot(pop, 1F);
                        playAfterDeath = false;
                    }
                }
            }
        }
    }


}

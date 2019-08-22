using UnityEngine;

public class Health3B : MonoBehaviour
{
    //attributes
    public static int health;
    public GameObject Heart1, Heart2, Heart3;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
        {
            health = 3;
        }

        switch (health)
        {
            case 3: //sets three hearts active if health=3
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                break;
            case 2: //sets two hearts active if health=2
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                break;
            case 1: //sets one heart active if health=1
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
            case 0: //sets zero hearts active if health=0
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
        }
    }

    //returns true if health>0
    public static bool IsAlive()
    {
        if (health > 0)
        {
            return true;
        }
        return false;
    }
}

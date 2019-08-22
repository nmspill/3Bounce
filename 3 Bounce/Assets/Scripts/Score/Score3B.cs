using TMPro;
using UnityEngine;

public class Score3B : MonoBehaviour
{
   //attributes
    private TextMeshProUGUI ScoreBoard;
    public static int scoreText; 

    // Start is called before the first frame update
    void Start()
    { 
        scoreText = PlayerPrefs.GetInt("GameScore");
        ScoreBoard = GetComponent<TextMeshProUGUI>();
        ChangeFontColor(ScoreBoard);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoard.text = scoreText.ToString();
    }

    //changes the text color
    public static void ChangeFontColor(TextMeshProUGUI score)
    {
        if (PlayerPrefs.GetInt("DarkMode") == 1)
        {
            score.color = DarkMode3B.lightColor;
        }
        else
        {
            score.color = DarkMode3B.darkColor;
        }

    }

}

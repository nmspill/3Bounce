using TMPro;
using UnityEngine;



public class HighScore3B : MonoBehaviour
{

    private TextMeshProUGUI HighScoreText;

    // Start is called before the first frame update
    void Start()
    {

        HighScoreText  = GetComponent<TextMeshProUGUI>();
        HighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString() + "<sprite=0>";

        if(Score3B.scoreText > PlayerPrefs.GetInt("HighScore", 0)) //checks if the current score is greater than the current high score
        {
            PlayerPrefs.SetInt("HighScore", Score3B.scoreText);
            HighScoreText.text = Score3B.scoreText.ToString() + "<sprite=0>";
        }

        Score3B.ChangeFontColor(HighScoreText); //changes font color based on dark or light mode
    }

    
}

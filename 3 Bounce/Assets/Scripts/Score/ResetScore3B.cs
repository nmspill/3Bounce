using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore3B : MonoBehaviour
{

    public void ResetGameScore()
    {
        PlayerPrefs.SetInt("GameScore", 0); //changes score to 0
        PlayerPrefs.SetInt("CanWatchAd", 0); //allows the ad button to be enabled
    }

    
}


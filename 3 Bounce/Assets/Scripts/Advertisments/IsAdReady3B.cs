using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.UI;

public class IsAdReady3B : MonoBehaviour
{
    //attributes
    public string placementId = "rewardedVideo";
    public Button AdButton;

    //choses GameID based on platform
    #if UNITY_IOS
    private string gameId = "3220540";
    #elif UNITY_ANDROID
        private string gameId = "3220541";
    #endif

    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(gameId, true);
    }

    void Update()
    {
        if(!AdButton.IsActive()) //checks if adbutton is enabled
        {
            if (Monetization.IsReady(placementId)) //checks if an ad is ready
            {
                if (PlayerPrefs.GetInt("CanWatchAd") == 0) //checks if an ad was played already this game
                {
                    AdButton.gameObject.SetActive(true); //enables ad button
                }
            }
        }

        else if(PlayerPrefs.GetInt("CanWatchAd") != 0) //checks if an ad was played already this game
        {
            AdButton.gameObject.SetActive(false); //disabled ad button
        }
    }
}

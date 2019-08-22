using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.UI;


public class RewardedAd3B : MonoBehaviour
{

    //attributes
    public string placementId = "rewardedVideo";
    private Button rewardedAdButton;

    //choses GameID based on platform
    #if UNITY_IOS
    private string gameId = "3220540";
    #elif UNITY_ANDROID
        private string gameId = "3220541";
    #endif


    // Start is called before the first frame update
    void Start()
    {
        rewardedAdButton = GetComponent<Button>();
        if (rewardedAdButton)
        {
            rewardedAdButton.onClick.AddListener(ShowAd);
        }

        if (Monetization.isSupported) //checks if monetization is supported
        {
            Monetization.Initialize(gameId, true); //initialized gameId
        }
    }

    void Update()
    {
        if (rewardedAdButton)
        {
            rewardedAdButton.interactable = Monetization.IsReady(placementId);
        }
    }

    void ShowAd()
    {
        ShowAdCallbacks options = new ShowAdCallbacks();
        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
        ad.Show(options);
    }

    //handles the result of the ad (finished, skipped, or failed)
    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            RewardPlayer3B.RewardPlayer();
        }
        else if (result == ShowResult.Skipped)
        {
            PlayerPrefs.SetInt("GameScore", 0); //sets the score back to 0
            PlayerPrefs.SetInt("CanWatchAd", 1); //disables ad button

        }
        else if (result == ShowResult.Failed)
        {
            PlayerPrefs.SetInt("GameScore", 0); //sets the score back to 0;
            PlayerPrefs.SetInt("CanWatchAd", 1); //disables ad button

        }
    }
}

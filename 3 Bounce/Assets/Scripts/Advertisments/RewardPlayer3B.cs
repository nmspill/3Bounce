using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardPlayer3B : MonoBehaviour
{ 
    public static void RewardPlayer()
    {
        SceneManager.LoadScene("Game"); //reloads the 'Game' scene
        PlayerPrefs.SetInt("CanWatchAd", 1); //disables the ad button
    }
}

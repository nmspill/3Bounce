using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class SettingsButton3B : MonoBehaviour
{
    //attributes
    public Sprite DarkButton, LightButton;
    public Button TheSettingsButton;
    AudioSource Audio;
    public AudioClip buttonSound;
    bool LoadingInitiated = false;


    void Start()
    {
        SettingsButtonSprite();
        Audio = GetComponent<AudioSource>();

    }

    //Loads the 'Settings' scene
    public void SettingsButton(string settings)
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            if (!LoadingInitiated)
            {
                StartCoroutine(DelayedLoad(settings));
                LoadingInitiated = true;
            }
        }
        else
        {
            SceneManager.LoadScene(settings);
        }
    }

    //changes the settings button sprite
    private void SettingsButtonSprite()
    {
        if (PlayerPrefs.GetInt("DarkMode") == 1)
        {
            TheSettingsButton.GetComponent<Image>().sprite = LightButton;
        }
        else
        {
            TheSettingsButton.GetComponent<Image>().sprite = DarkButton;
        }
    }

    //waits for audio to play before changing scenes
    IEnumerator DelayedLoad(string scene)
    {
        //Play the clip once
        Audio.PlayOneShot(buttonSound, 1F);

        //Wait until clip finish playing
        yield return new WaitForSeconds(buttonSound.length);

        //Load the scene
        SceneManager.LoadScene(scene);


    }
}

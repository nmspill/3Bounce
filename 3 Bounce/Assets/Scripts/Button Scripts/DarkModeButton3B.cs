using UnityEngine;
using UnityEngine.UI;

public class DarkModeButton3B : MonoBehaviour
{
    //attributes
    public Camera MainCam;
    public Sprite DarkButton, LightButton;
    public Button TheDarkModeButton;
    AudioSource Audio;
    public AudioClip buttonSound;


    private void Start()
    {
        DarkModeSprite();
        Audio = GetComponent<AudioSource>();
    }

    //Changes the theme to darkmode or lightmode
    public void DarkModeButton()
    {
        if(PlayerPrefs.GetInt("Sound") == 0)
        {
            Audio.PlayOneShot(buttonSound, 1F);
        }
        
        if (PlayerPrefs.GetInt("DarkMode") == 1)
        {
            TheDarkModeButton.GetComponent<Image>().sprite = DarkButton;
            PlayerPrefs.SetInt("DarkMode", 0);
            MainCam.backgroundColor = DarkMode3B.lightColor;
           
        }
        else
        {
            TheDarkModeButton.GetComponent<Image>().sprite = LightButton;
            PlayerPrefs.SetInt("DarkMode", 1);
            MainCam.backgroundColor = DarkMode3B.darkColor;
        }

    }

    //changes the sprite of the dark mode button
    private void DarkModeSprite()
    {
        if (PlayerPrefs.GetInt("DarkMode") == 1)
        {
            TheDarkModeButton.GetComponent<Image>().sprite = LightButton;
        }
        else
        {
            TheDarkModeButton.GetComponent<Image>().sprite = DarkButton;
        }
    }
}

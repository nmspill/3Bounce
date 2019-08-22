using UnityEngine.UI;
using UnityEngine;

public class SoundButton3B : MonoBehaviour
{
    //attributes
    public Sprite SoundOn, SoundOff;
    public Button SoundButton;
    AudioSource Audio;
    public AudioClip buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        VolumeButtonSprite();
        Audio = GetComponent<AudioSource>();
    }

    //Turns on and off the sound
    public void VolumeButton()
    {
      

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            Audio.PlayOneShot(buttonSound, 1F);
            SoundButton.GetComponent<Image>().sprite = SoundOn;
            PlayerPrefs.SetInt("Sound", 0);

        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = SoundOff;
            PlayerPrefs.SetInt("Sound", 1);
        }

    }

    //changes the sprite of the volume button
    private void VolumeButtonSprite()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            SoundButton.GetComponent<Image>().sprite = SoundOn;
        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = SoundOff;
        }
    }
}

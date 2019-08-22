using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonManager3B : MonoBehaviour
{
    //attributes
    AudioSource Audio;
    public AudioClip buttonSound;
    bool LoadingInitiated = false;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    //Loads the 'Game' Scene 
    public void PlayButton(string game)
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            if (!LoadingInitiated)
            {
                StartCoroutine(DelayedLoad(game));
                LoadingInitiated = true;
            }
        }
        else
        {
            SceneManager.LoadScene(game);
        } 
    }

    //Loads the 'Start Menu' scene
    public void HomeButton(string startScreen)
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            if (!LoadingInitiated)
            {
                StartCoroutine(DelayedLoad(startScreen));
                LoadingInitiated = true;
            }
        }
        else
        {
            SceneManager.LoadScene(startScreen);
        }
    }

    //waits for the sound to play before a scene is loaded
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
 


using UnityEngine;

public class DarkMode3B : MonoBehaviour
{
    //attributes
    public Camera MainCam;
    public static Color32 darkColor = new Color32(49, 49, 49, 255);
    public static Color lightColor = Color.white;

    void Start()
    {
        ChangeCameraBackground();
    }

    //Changes the background
    private void ChangeCameraBackground()
    {
        if (PlayerPrefs.GetInt("DarkMode") == 1)
        {
            MainCam.backgroundColor = darkColor;
        }

        else
        {
            MainCam.backgroundColor = lightColor;
        }
       
    }
}

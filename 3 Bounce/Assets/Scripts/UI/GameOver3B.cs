using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class GameOver3B : MonoBehaviour
{
    public GameObject GameOverUI;

    private void Start()
    {
        GameOverUI.SetActive(false);
    }

    void Update()
    {
        EndGame();
    }

    //Makes the Restart, Home button, and Ad button active when you run out of lives
    private void EndGame()
    {
        if (!Health3B.IsAlive())
        {
            GameOverUI.SetActive(true);
        }

    }
}

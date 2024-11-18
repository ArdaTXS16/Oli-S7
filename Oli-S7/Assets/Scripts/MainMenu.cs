using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelection");
        Debug.Log("Spiel gestartet");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
        Debug.Log("Settings geöffnet");
    }

    public void QuitGame()
    {
        Debug.Log("Spiel beendet");
        Application.Quit();
    }
}
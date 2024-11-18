using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    public Color lockedColor = Color.red;

    void Start()
    {
        // Hier könntest du gespeicherte Fortschritte laden
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1); // Das freigeschaltete Level aus den PlayerPrefs laden

        // Buttons aktivieren oder deaktivieren und die Farbe ändern
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Button button = levelButtons[i];
            Image buttonImage = button.GetComponent<Image>(); // Hole die Image-Komponente des Buttons

            // Stelle sicher, dass Level 1 immer aktiv bleibt
            if (i == 0) // Level 1 (Index 0)
            {
                button.interactable = true; // Level 1 bleibt immer aktiv
                buttonImage.color = Color.white; // Setze die Farbe auf normal
            }
            else
            {
                // Für alle anderen Levels (ab Level 2)
                if (i + 1 > levelReached)
                {
                    button.interactable = false; // Button deaktivieren
                    buttonImage.color = lockedColor; // Setze die Farbe auf rot (oder jede andere Farbe)
                }
                else
                {
                    button.interactable = true; // Button aktivieren
                    buttonImage.color = Color.white; // Setze die Farbe zurück auf die normale Farbe (weiß)
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    public void SelectLevel(int levelIndex)
    {
        // Szene für das ausgewählte Level laden
        SceneManager.LoadScene("Level" + levelIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLvl2 : MonoBehaviour
{
    // Called when we click the "Restart" button.
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level 2 calvin 1");
    }

    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

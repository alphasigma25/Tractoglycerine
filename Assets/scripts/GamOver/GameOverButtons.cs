using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level 1 calvin");
    }


    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gagné_Encore : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level 1 calvin 1");
    }

    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

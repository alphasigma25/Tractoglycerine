using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinal : MonoBehaviour
{
    // Called when we click the "Play" button.
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Lvl1Victor");
    }

    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

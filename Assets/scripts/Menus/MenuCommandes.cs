using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCommandes : MonoBehaviour
{
    // Called when we click the "GO!" button.
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level 1 calvin 1");
    }
}

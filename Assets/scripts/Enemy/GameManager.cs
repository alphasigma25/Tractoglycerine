using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnerManager Spawner;
    [SerializeField] GameObject WinPanel;

    public bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        Spawner = GameObject.Find("Spawner").GetComponent<SpawnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Spawner.enemies.Count == 0 && Spawner.nb_created == Spawner.data.maxEnemies) 
        { 
            //WIN
            WinPanel.SetActive(true);
            hasWon = true;
        }
    }
}

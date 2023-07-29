using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<SpawnerManager> Spawners;
    [SerializeField] GameObject WinPanel;
    public bool hasWon { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hasWon = true;
        foreach (var spawner in Spawners)
        {
            // opération booléenne, on calcule si tous les ennemis de tous les spawners sont éliminés
            hasWon &= (spawner.enemies.Count == 0 && spawner.nb_created == spawner.data.maxEnemies);
        }
        WinPanel.SetActive(hasWon);
    }
}

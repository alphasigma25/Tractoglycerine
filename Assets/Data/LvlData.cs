using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "LvlData", order = 1)]
public class LvlData : ScriptableObject
{
    public List<GameObject> monsters;

    [Header("Spawn Params")]
    public float spawnFreq;
    public int maxEnemies;
}
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SpawnerData", order = 1)]
public class SpawnerData : ScriptableObject
{
    public GameObject EnemyObject;

    public List<EnemyData> enemies;

    [Header("Spawn Params")]
    public float startSpwaning = 0;
    public float spawnFreq;
    public int maxEnemies;
}
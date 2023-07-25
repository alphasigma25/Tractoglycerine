using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "MonsterData", order = 1)]
public class MonsterData : ScriptableObject
{
    public float vitesse;

    public Color color;

    [Header("Resistance")]
    public int res1;
    public int res2;
    public int res3;
    public int res4;
}
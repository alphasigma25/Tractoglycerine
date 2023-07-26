using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [Header("GameObject properties")]
    public Sprite sprite;
    public Color color;
    public float mass = 1;

    [Header("Game properties")]
    public float speed;
    public int initHealth;
    public int damage;

    [Header("Weaknesses")]
    public int w1;
    public int w2;
}
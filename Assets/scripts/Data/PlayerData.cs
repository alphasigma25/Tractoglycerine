using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public List<GameObject> Projectiles;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject m_Enemy;
    public int maxEnemy;
    public float spawnFreq;
    private float timer;

    List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnFreq && enemies.Count < maxEnemy)
        {
            enemies.Add(Instantiate(m_Enemy, transform.position + Random.onUnitSphere, Quaternion.identity));
            timer = 0;
        }
    }
}

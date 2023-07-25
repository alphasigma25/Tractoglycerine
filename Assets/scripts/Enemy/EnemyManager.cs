using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject m_Enemy;

    private float timer;
    public LvlData data;
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
        if (timer > data.spawnFreq && enemies.Count < data.maxEnemies)
        {
            GameObject newEnemy = Instantiate(m_Enemy, transform.position + Random.onUnitSphere, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().data = data.monsters[Random.Range(0, data.monsters.Count)];
            enemies.Add(newEnemy);
            timer = 0;
        }
    }
}

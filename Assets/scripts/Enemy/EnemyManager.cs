using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float timer;
    private int nb_created;
    public LvlData data;
    List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        nb_created = 0;
        timer = 0;
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > data.spawnFreq && nb_created < data.maxEnemies)
        {
            GameObject newEnemy = Instantiate(data.monsters[Random.Range(0, data.monsters.Count)], transform.position + Random.onUnitSphere, Quaternion.identity);
            enemies.Add(newEnemy);
            timer = 0;
            nb_created++;
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            if (enemy.GetComponent<Enemy>().health == 0)
            {
                Debug.Log($"destroy {enemy}");
                enemies.RemoveAt(i);
                i--;
                Destroy(enemy);
            }
        }
    }
}

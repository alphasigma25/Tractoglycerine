using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    private float timer;
    private int nb_created;
    public SpawnerData data;
    List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        nb_created = 0;
        timer = 0;
        enemies = new List<GameObject>();
    }

    private void CreateEnemy()
    {
        GameObject newEnemy = Instantiate(data.EnemyObject, transform.position + Random.onUnitSphere, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().data = data.enemies[Random.Range(0, data.enemies.Count)];
        enemies.Add(newEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > data.spawnFreq && nb_created < data.maxEnemies)
        {
            CreateEnemy();
            nb_created++;
            timer = 0;
        }

        if (nb_created < data.maxEnemies && enemies.Count == 0)
        {
            Debug.Log("lvl finished");
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            if (enemy.GetComponent<Enemy>().health == 0)
            {
                enemies.RemoveAt(i);
                i--;
                Destroy(enemy);
            }
        }
    }
}

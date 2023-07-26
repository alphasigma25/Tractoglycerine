using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTransfo;
    private Vector3 direction;
    public int health { get; private set; } = 1; //un hack car quand objet créé, health a pas encore été init (donc =0) et on va le supprimer directement dans le manager
    public EnemyData data { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        playerTransfo = GameObject.FindGameObjectWithTag("Player").transform;
        health = data.initHealth;
        gameObject.GetComponent<SpriteRenderer>().color = data.color;
        gameObject.GetComponent<SpriteRenderer>().sprite = data.sprite;
        gameObject.GetComponent<Rigidbody2D>().mass = data.mass;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (playerTransfo.position - transform.position).normalized;
        transform.position += direction * data.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.tag == "Projectile")
        {
            var proj = collided.GetComponent<Projectile>();
            switch (proj.projectileType)
            {
                case ProjectileType.T1: health -= data.w1; break;
                case ProjectileType.T2: health -= data.w2; break;
                default: break;
            }
            Destroy(collided);
        }
    }
}

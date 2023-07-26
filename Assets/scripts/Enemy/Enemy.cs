using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    private Transform playerTransfo;
    private Vector3 direction;

    [Header("Properties")]
    [SerializeField] private float speed;
    public int health = 100;
    public int damage = 50;

    [Header("Weakness")]
    [SerializeField] private int weak1;
    [SerializeField] private int weak2;
    [SerializeField] private int weak3;
    [SerializeField] private int weak4;

    // Start is called before the first frame update
    void Start()
    {
        playerTransfo = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (playerTransfo.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.tag == "Projectile")
        {
            Debug.Log($"collided {collided}");
            var proj = collided.GetComponent<Projectile>();
            switch (proj.projectileType)
            {
                case ProjectileType.T1: health -= weak1; break;
                case ProjectileType.T2: health -= weak2; break;
                case ProjectileType.T3: health -= weak3; break;
                case ProjectileType.T4: health -= weak4; break;
                default: break;
            }
            Destroy(collided);
        }
    }
}

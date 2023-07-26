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

    [Header("Resistance")]
    [SerializeField] private int res1;
    [SerializeField] private int res2;
    [SerializeField] private int res3;
    [SerializeField] private int res4;

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
            health = 0;
            Destroy(collided);
        }
    }
}

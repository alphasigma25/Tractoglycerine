using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTransfo;
    private Vector3 direction;
    public int health /*{ get;  private set; }*/ = 1; //un hack car quand objet cr??, health a pas encore ?t? init (donc =0) et on va le supprimer directement dans le manager
    public EnemyData data { get; set; }

    [SerializeField] private Transform objectToRotate;
    [SerializeField] private float rotationAmplitude = 20f;
    [SerializeField] private float rotationSpeed = 0.001f;

    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransfo = GameObject.FindGameObjectWithTag("Player").transform;
        health = data.initHealth;
        gameObject.GetComponent<MeshRenderer>().material.color = data.color;
        gameObject.GetComponent<Rigidbody2D>().mass = data.mass;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (playerTransfo.position - transform.position).normalized;
        transform.position += direction * data.speed * Time.deltaTime;
        transform.LookAt(playerTransfo.position, Vector3.back);

        timer += Time.deltaTime;
        float rotation = Mathf.Sin(timer * rotationSpeed);
        rotation *= rotationAmplitude;
        rotation -= 90f;
        Debug.Log(rotation);
        Vector3 oldRotation = objectToRotate.localRotation.eulerAngles;
        oldRotation.x = rotation;
        oldRotation.y = 90f;
        oldRotation.z = -90f;
        objectToRotate.localRotation = Quaternion.Euler(oldRotation);
        Debug.Log(objectToRotate.localRotation);
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
        if (collided.tag == "Killer" && collided.transform.position.z > -0.5)
        {
            health = 0;
        }
    }
}

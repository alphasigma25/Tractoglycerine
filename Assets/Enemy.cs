using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTransfo;
    public float vitesse;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        playerTransfo = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        direction = (playerTransfo.position - transform.position).normalized;
        transform.position += direction * vitesse * Time.deltaTime;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTransfo;
    public MonsterData data;
    private Vector3 direction;

    private SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerTransfo = GameObject.FindGameObjectWithTag("Player").transform;

        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = data.color;
        Debug.Log(m_SpriteRenderer.color);
    }

    // Update is called once per frame
    void Update()
    {
        direction = (playerTransfo.position - transform.position).normalized;
        transform.position += direction * data.vitesse * Time.deltaTime;
    }
}

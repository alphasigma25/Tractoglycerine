using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using UnityEngine;

using Random = UnityEngine.Random;

public class Foot : MonoBehaviour
{
    public float LifeTime = 5;
    public float spawnWidth = 2;
    public float spawnHeight = 2;
    public float initHeight = 5;
    public float amplitude = 3;
    public float speed = 5;
    private Vector3 direction;

    private float mW;
    private float mH;

    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        mW = spawnWidth / 2f;
        mH = spawnHeight / 2f;
        transform.position = new(Random.Range(-mW, mW), Random.Range(-mH, mH), initHeight);

        direction = Random.onUnitSphere.normalized * Mathf.Min(mW, mH);
        direction.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(direction.x * speed * Time.deltaTime, direction.z * speed * Time.deltaTime, (Mathf.Cos(time * 5)) * Time.deltaTime * amplitude);

        if (transform.position.x > mW) direction.x *= -1;
        if (transform.position.x < -mW) direction.x *= -1;
        if (transform.position.y > mH) direction.x *= -1;
        if (transform.position.y < -mH) direction.x *= -1;

        if (time > LifeTime)
        {
            Destroy(gameObject);
        }
    }
}

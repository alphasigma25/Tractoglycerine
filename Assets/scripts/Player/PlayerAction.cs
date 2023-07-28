using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;


public class PlayerAction : MonoBehaviour
{
    //Reference Scripts
    private PlayerController _playerController;
    public List<GameObject> Projectiles;
    private GameManager GM;
    [SerializeField]
    private GameObject foot;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();

    }

    void Start()
    {

    }

    void Update()
    {
        if (_playerController.Action1)
        {
            if (Projectiles.Count == 0) { Debug.Log("Projectiles list is empty in Player GameObject"); }
            var dir = GetComponent<PlayerMovement>().Direction;
            GameObject newProjectile = Instantiate(Projectiles[0], transform.position + dir, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().direction = dir;
        }

        if (_playerController.Action2 && Projectiles.Count > 1)
        {
            var dir = GetComponent<PlayerMovement>().Direction;
            GameObject newProjectile = Instantiate(Projectiles[1], transform.position + dir, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().direction = dir;
        }

        if (_playerController.Action3 && true)
        {
            Instantiate(foot, Random.insideUnitCircle, Quaternion.identity);
        }
    }
}

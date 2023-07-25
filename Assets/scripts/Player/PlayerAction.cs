using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //Reference Scripts
    private PlayerController _playerController;

    private float _distance = 0.0f;

    public GameObject Projectile;


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
           GameObject newProjectile = Instantiate(Projectile, transform.position, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().direction = GetComponent <PlayerMovement> ().Direction;
        }
    }
}

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

    public GameObject foot;

    private Animator animator;

    private bool invocation_available = true;

    private AudioSource[] _audioSource;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        _audioSource = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (_playerController.Action1)
        {
            if (Projectiles.Count == 0) { Debug.Log("Projectiles list is empty in Player GameObject"); }
            var dir = GetComponent<PlayerMovement>().Direction;
            GameObject newProjectile = Instantiate(Projectiles[0], transform.position + dir, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().direction = dir;
            PlayShootAnimation();
            ProjectilShootAnimation();

            _audioSource[0].Play();
        }

        if (_playerController.Action2 && Projectiles.Count > 1)
        {
            var dir = GetComponent<PlayerMovement>().Direction;
            GameObject newProjectile = Instantiate(Projectiles[1], transform.position + dir, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().direction = dir;
            PlayShootAnimation();
            ProjectilShootAnimation();

            _audioSource[0].Play();
        }

        if (_playerController.Action3 && invocation_available)
        {
            Instantiate(foot, Vector3.zero, Quaternion.identity);
            invocation_available = false;
            _audioSource[1].Play();
        }
    }

    void PlayShootAnimation()
    {
        animator.SetTrigger("Shoot");
    }

    void ProjectilShootAnimation()
    {
        animator.SetTrigger("ProjectilShoot");
    }
}

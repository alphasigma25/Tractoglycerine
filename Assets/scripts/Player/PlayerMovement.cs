using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference Scripts
    private PlayerController _playerController;
    private Animator animator;
    private AudioSource _audioSource;

    [SerializeField] private float Speed = 4.0f;
    public Vector3 Direction { get; set; } = Vector3.right;
    bool isPlaying = false;
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        _audioSource = GetComponents<AudioSource>()[2];
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = _playerController.Movement.x;
        direction.y = _playerController.Movement.y;
        if (direction.magnitude > 0.001f)
        {
            Direction = Vector3.Normalize(direction);
        }
        transform.Translate(Vector3.Normalize(direction) * Time.deltaTime * Speed, Space.World);
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 2 * Mathf.PI);
            if(!isPlaying)
            {
                isPlaying = true;
                _audioSource.Play();
            }

        }

        if (direction == Vector3.zero)
        {
            if (isPlaying)
            {
                isPlaying = false;
                _audioSource.Pause();
            }
        }
            animator.SetFloat("Speed", direction.magnitude);

    }
}

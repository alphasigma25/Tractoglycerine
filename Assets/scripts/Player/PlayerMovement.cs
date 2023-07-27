using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference Scripts
    private PlayerController _playerController;

    [SerializeField] private float Speed = 4.0f;
    [SerializeField] private float RotationSpeed = 720f;
    public Vector3 Direction { get; set; } = Vector3.right;
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    void Start()
    {

    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = _playerController.Movement.x;
        direction.y = _playerController.Movement.y;
        if (direction.magnitude > 0.01f)
        {
            Direction = Vector3.Normalize(direction);
        }
        transform.Translate(Vector3.Normalize(direction) * Time.deltaTime * Speed, Space.World);
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);
        }
    }
}

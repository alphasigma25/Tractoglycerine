using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference Scripts
    private PlayerController _playerController;

    [SerializeField] private float _speed = 4.0f;
    public Vector3 Direction { get; set; }
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
        Direction = Vector3.Normalize(direction);
        transform.position += Direction * Time.deltaTime * _speed;

    }
}

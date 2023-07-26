using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference Scripts
    private PlayerController _playerController;

    [SerializeField] private float _speed = 4.0f;
    public float value = 1;
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
        if (Mathf.Abs(direction.x) > value && Mathf.Abs (direction.y) > value)
        {
            Direction = Vector3.Normalize(direction);
        }
        transform.position += Vector3.Normalize (direction) * Time.deltaTime * _speed;

    }
}

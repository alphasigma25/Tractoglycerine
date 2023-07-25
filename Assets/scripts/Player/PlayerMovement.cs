using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference Scripts
    private PlayerController _playerController;

    [SerializeField] private float _speed = 4.0f;


    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    void Start()
    {

    }

    void Update()
    {
        //transform.position += new Vector3(_playerController.Movement.x * Time.deltaTime, _playerController.Movement.y * Time.deltaTime, 0.0f) * _speed;
        Debug.Log(Time.deltaTime*_speed);
        Vector3 position = Vector3.zero;
        position.x = _playerController.Movement.x;
        position.y = _playerController.Movement.y;
        transform.position += Vector3.Normalize(position) * Time.deltaTime * _speed;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Reference Scripts
    private PlayerInput _playerInput;

    private string _controlScheme;

    //Movement Vectors
    private Vector2 _movement;
    private Vector2 _aim;

    //Action bools
    private bool _action1;

    //Game State bools
    public bool play = true;
    public delegate void Pause(bool isActive);
    public Pause GameState;

    //Repeating logic
    private bool _canRepeateActions = false;
    private bool _repeatingAction1 = false;
    private float _repeatingTimer = 0.1f;
    private float _repeatTimerAction1;


    //Properties
    public string ControlScheme { get => _controlScheme; set => _controlScheme = value; }
    public Vector2 Movement { get => _movement; set => _movement = value; }
    public Vector2 Aim { get => _aim; set => _aim = value; }
    public bool Action1 { get => _action1; set => _action1 = value; }
    public bool CanRepeateActions { get => _canRepeateActions; set => _canRepeateActions = value; }

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        _controlScheme = _playerInput.currentControlScheme;

        if (!_canRepeateActions)
        {
            if (_repeatingAction1)
            {
                _repeatTimerAction1 += Time.deltaTime;
            }
            if (_repeatTimerAction1 >= _repeatingTimer)
            {
                _action1 = true;
                _repeatingAction1 = false;
                _repeatTimerAction1 = 0.0f;
            }
            else
            {
                _action1 = false;
            }
        }
    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }
    public void OnAim(InputValue value)
    {
        switch (_controlScheme)
        {
            case "Keyboard":
                break;
            case "Gamepad":
                _aim = value.Get<Vector2>();
                break;
            default:
                break;
        }

    }
    public void OnAction1(InputValue value)
    {
        if (!_canRepeateActions)
        {
            if (value.isPressed)
                _repeatingAction1 = true;

        }
        else
        {
            _action1 = value.isPressed;
        }
    }

    public void OnPause(InputValue value)
    {
        play = !play;
        Time.timeScale = play ? 1.0f : 0.0f;
        GameState(play);
    }
}

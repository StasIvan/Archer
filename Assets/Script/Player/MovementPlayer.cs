using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[DisallowMultipleComponent]
public class MovementPlayer : MonoBehaviour
{
    CharacterController _controller;
    [SerializeField] float _characterSpeed = 10.0f;
    Movement _movement;
    Transform _thisTransform;
    float _gravityValue = -9.8f;
    float _currentGravity = 0;
    private void Start()
    {
        _thisTransform = transform;
        _controller = GetComponent<CharacterController>();
        _movement = GetComponent<Movement>();
    }
    private void Update()
    {
        CharacterMove();
    }
    void CharacterMove()
    {
        if (_controller.isGrounded)
            _currentGravity = 0;

        else
            _currentGravity += _gravityValue;

        Vector3 move = Vector3.forward * FloatingJoystick.joystick.Vertical + Vector3.right * FloatingJoystick.joystick.Horizontal;
        _movement.Move(_controller, move + Vector3.up * _currentGravity, _characterSpeed);
        _movement.LookAtDirection(_thisTransform, move);
    }
}


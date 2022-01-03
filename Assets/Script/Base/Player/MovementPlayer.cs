using UnityEngine;

[DisallowMultipleComponent]
public class MovementPlayer : Movement
{
    [SerializeField] private float _characterSpeed = 10.0f;
    [HideInInspector] public Transform thisTransform;
    
    private void Start()
    {
        thisTransform = transform;
        SetPreviousPos(thisTransform);
    }

    private void Update()
    {
        CharacterMove();
    }

    private void CharacterMove()
    {
        Vector3 input = Input();
        Move(thisTransform, input , _characterSpeed);
        LookAtDirection(thisTransform, input);
    }

    private Vector3 Input()
    {
        return Vector3.forward * FloatingJoystick.joystick.Vertical + Vector3.right * FloatingJoystick.joystick.Horizontal;
    }

}


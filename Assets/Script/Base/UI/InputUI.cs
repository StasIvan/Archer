using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputUI : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private void Awake()
    {
        _joystick.SetActive();
    }
}

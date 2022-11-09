using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputJoyStickController : MonoBehaviour
{
    [SerializeField] FloatingJoystick joystick;

    Vector3 _direction;
    public Vector3 Output => _direction;

    public void InputUpdate()
    {
        _direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;     
    }
}

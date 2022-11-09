using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float Thrust = 4f;

    public void MovementUpdate(Vector3 output)
    {
        transform.position += output * Thrust * Time.deltaTime;
        transform.LookAt(transform.position + output);
       
    }
}

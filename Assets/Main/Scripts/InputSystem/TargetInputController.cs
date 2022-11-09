using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInputController : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    public bool IsTargetExist(Vector3 position, float maxDistance)
    {
        RaycastHit hit;
        if (Physics.Raycast(position, -Vector3.up, out hit, maxDistance, layerMask)) return true;
        else return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHandler : MonoBehaviour
{
    [SerializeField] PoolManager _poolManager;
    PooledObject _pooledObject;

    public void GetPooledObject(Transform objectTransform, string poolName)
    {
        _pooledObject = _poolManager.GetItemByName(poolName);
        if (_pooledObject != null)
        {
            _pooledObject.SetPosition(objectTransform.position);
        }     
    }

    public void Dismiss()
    {
        _pooledObject.Dismiss();
    }
}

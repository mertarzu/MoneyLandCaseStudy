using UnityEngine;

public abstract class PooledObject : MonoBehaviour
{
    public abstract bool IsPooledObjectTaken { get; }
    public abstract void SetActive();
    public abstract void Dismiss();
    public abstract void SetPosition(Vector3 pos);
}


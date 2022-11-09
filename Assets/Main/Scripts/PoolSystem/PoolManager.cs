using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;
    public static PoolManager Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] List<ObjectPooler> _objectpoolers = new List<ObjectPooler>();
  
    public ObjectPooler this[int i] => _objectpoolers[i];
    
    public PooledObject GetItemByIndex(int index)
    {
        return _objectpoolers[index].GetPooledObject();
    }
    public PooledObject GetItemByName(string poolName)
    {
        return _objectpoolers.Where(i => i.GetPoolName() == poolName).FirstOrDefault().GetPooledObject();
    }

    public void ReleaseAll()
    {
        
        for(int i = 0; i < _objectpoolers.Count; i++)
        {
            for(int j = 0; j < _objectpoolers[i].PooledObjects.Count; j++)
            {
                _objectpoolers[i].PooledObjects[j].Dismiss();
            }
        }       
    }
}

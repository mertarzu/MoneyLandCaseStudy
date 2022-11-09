using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyContainer : MonoBehaviour
{
    [SerializeField] Transform _moneyTransform;
    [SerializeField] Transform _moneyParentTransform;
    
    public void StartGame()
    {
        Invoke("GetMoney", .1f);
    }
    void GetMoney()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Money money = (Money)PoolManager.Instance.GetItemByName("Money");
                money.gameObject.transform.parent = _moneyParentTransform;
                money.Move(_moneyTransform, new Vector3(i, 0, j));
                money.SetActive();
            }
        }

    }

}
    

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasedItemProduction : MonoBehaviour
{
    [SerializeField] Transform _moneyTransform;
    [SerializeField] Transform _moneyParentTransform;
    Vector3 _max = new Vector3(5, 5, 5);
    Vector3 _index;
    int _productAmount;
    float _timeCounter;
    bool _isProduction;
    int _totalProductAmount;
   
    const float ProductTime = 2f;
    public void StartProduction(int productAmount)
    {
        _productAmount = productAmount;
        _isProduction = true;
    }
    private void Update()
    {
        if (!_isProduction) return;

        _timeCounter += Time.deltaTime;

        if (_timeCounter >= ProductTime)
        {
            for (int i = 0; i < _productAmount; i++)
            {
                if (_index.y == _max.y)
                {
                    _isProduction = false;
                    return;
                }             
                bool isFirstRound;
                if (_index.z == 0) isFirstRound = true;
                else isFirstRound = false;

                _index.z = _totalProductAmount % _max.z;
                if (_index.z == 0 && !isFirstRound) _index.x++;
                if(_index.x == _max.x)
                {
                    _index.x = 0;
                    _index.y++;
                }
                Money money = (Money)PoolManager.Instance.GetItemByName("Money");
                money.gameObject.transform.parent = _moneyParentTransform;
                money.Move(_moneyTransform, _index);
                money.SetActive();
                _totalProductAmount++;
            }          
            _timeCounter = 0;

        }
    }
}

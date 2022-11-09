using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyHandler : MonoBehaviour
{
    public Action OnMoneyChange;
    [SerializeField] PlayerSensor _playerSensor;
    [SerializeField] Transform _moneyTransform;
    [SerializeField] Transform _middleTransform;

    List<Money> _collectedMoney = new List<Money>();
    PurchasedItemSale _purchasedItem;
    int _price;
  
    public void Initialize()
    {
        _playerSensor.OnMoneyPickupTriggered += OnMoneyPickupTriggered;
        _playerSensor.OnMoneyDropTriggered += OnMoneyDropTriggered;
    }

    public void StartGame()
    {
        
    }
    public void GameOver()
    {
        
    }

    private void OnMoneyPickupTriggered(Money money)
    {
        money.gameObject.transform.parent = _playerSensor.transform;
        _collectedMoney.Add(money);
        moneyUpdate(1);
        money.Move(_moneyTransform,_middleTransform, _collectedMoney.Count);
    }

    void OnMoneyDropTriggered(PurchasedItemSale purchasedItem)
    { 
        int cash = _collectedMoney.Count * 10;
        _price = purchasedItem.AmountToComplete;
        int j = 0;
        bool isLastOne = false;
        while (_price > 0 && cash > 0)
        {          
            int i = _collectedMoney.Count - 1;
            _price -= 10;
            if (_price == 0)
            {
                isLastOne = true;
                _purchasedItem = purchasedItem;
            }

            StartCoroutine(WaitAndPay((j *.1f + .02f), _collectedMoney[i], purchasedItem.MoneyTransform,isLastOne));     
            _collectedMoney[i].OnPurchase += OnPurchase;         
            purchasedItem.AmountToComplete -= 10;
            purchasedItem.UpdatePriceText();
            moneyUpdate(-1);
            _collectedMoney.RemoveAt(i);
            cash = _collectedMoney.Count * 10;
            j++;         
        }      
    }

    IEnumerator WaitAndPay(float wait, Money money, Transform moneyTransform,bool isLastOne)
    {      
        yield return new WaitForSeconds(wait);       
        money.Move(moneyTransform);
        money.IsLastOne = isLastOne;
    }

    private void OnPurchase(bool isLastOne)
    {
       if (_price == 0 && isLastOne) _purchasedItem.MakePurchase();
    }

    void moneyUpdate(int amount)
    {
        PlayerHelper.UpdateMoneyAmount(amount);
        if (OnMoneyChange != null)
            OnMoneyChange();
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Locked,
    Sale,
    Production
}
public class PurchasedItem : MonoBehaviour
{
    public Action<int> OnUnlocked;
    [SerializeField] PurchasedItemLocked _purchasedItemLocked;
    [SerializeField] PurchasedItemSale _purchasedItemSale;
    [SerializeField] PurchasedItemProduction _purchasedItemProduction;
  
    public int Price => _purchasedItemSale.Price;
    int _productAmount;

    int _index;
    public void Initialize(int index, State state)
    {
        _purchasedItemSale.OnPurchased += OnPurchased;
        _purchasedItemSale.Initialize();
        SetState(state);
        _index = index;
        _productAmount = Price / 100;
   
    }

    public void StartSale()
    {
        SetState(State.Sale);
    }
    void StartProduction()
    {
        SetState(State.Production);
        _purchasedItemProduction.StartProduction(_productAmount);
    }
    void SetState(State state)
    {
    
        switch (state)
        {
            case State.Locked:
                _purchasedItemLocked.gameObject.SetActive(true);
                break;
            case State.Sale:
                _purchasedItemLocked.gameObject.SetActive(false);
                _purchasedItemSale.gameObject.SetActive(true);
                break;
            case State.Production:
                _purchasedItemSale.gameObject.SetActive(false);
                _purchasedItemProduction.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    void OnPurchased()
    {
        StartProduction();
        if (OnUnlocked != null)
        {
            OnUnlocked(_index);
        }
    }

   
}

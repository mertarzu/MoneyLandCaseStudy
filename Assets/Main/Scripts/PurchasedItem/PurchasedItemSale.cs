using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurchasedItemSale : MonoBehaviour
{
    public Action OnPurchased;
    [SerializeField] Transform _moneyTransform; 
    [SerializeField] TextMeshPro _priceText;
    [SerializeField] int _price;
    public int Price => _price;
    public Transform MoneyTransform => _moneyTransform;

    int _amountToComplete;
 
    public int AmountToComplete { get => _amountToComplete; set => _amountToComplete = value; }

    public void Initialize()
    {
        _amountToComplete = _price;
        int _completedAmount = _price - _amountToComplete;
        _priceText.text ="$" + _completedAmount.ToString() + " / $" + _price.ToString();
       
    }
    public void UpdatePriceText()
    {
        int _completedAmount = _price - _amountToComplete;
        _priceText.text = "$" + _completedAmount.ToString() + " / $" + _price.ToString();
    }
    public void MakePurchase()
    {
        if (OnPurchased != null)
        {
            OnPurchased();
        }
        gameObject.SetActive(false);
    }
}



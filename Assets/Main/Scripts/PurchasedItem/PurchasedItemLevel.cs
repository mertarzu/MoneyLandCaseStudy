using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasedItemLevel : MonoBehaviour
{
    [SerializeField] List<PurchasedItem> _purchasedItems = new List<PurchasedItem>();
    [SerializeField] List<State> _states = new List<State>();
    public void Initialize()
    {
        for (int i = 0; i < _purchasedItems.Count; i++)
        {
            _purchasedItems[i].Initialize(i, _states[i]);
            _purchasedItems[i].OnUnlocked += OnUnlocked;
        }
    }

    private void OnUnlocked(int index)
    {
        _states[index] = State.Production;
        index += 1;
        if (index == _states.Count) return;
        _states[index] = State.Sale;
        _purchasedItems[index].StartSale();
    }

}

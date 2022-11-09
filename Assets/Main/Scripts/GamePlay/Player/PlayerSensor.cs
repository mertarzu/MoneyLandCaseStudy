using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public Action<Money> OnMoneyPickupTriggered;
    public Action<PurchasedItemSale> OnMoneyDropTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money") && PlayerHelper.CanPickMoney())
        {
            Money money = other.GetComponent<Money>();

            if (OnMoneyPickupTriggered != null)
            {
                OnMoneyPickupTriggered(money);
            }
        }

        if (other.CompareTag("PurchasedItemPrice"))
        {
            if (DataHandler.Money == 0) return;
            PurchasedItemSale purchasedItem = other.GetComponent<PurchasedItemSale>();
            if (OnMoneyDropTriggered != null)
            {
                OnMoneyDropTriggered(purchasedItem);
            }
        }
    }
}

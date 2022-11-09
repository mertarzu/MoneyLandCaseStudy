using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PurchasedItemLevel", menuName = "PurchasedItemLevelCollection")]
public class PurchasedLevelItemCollection : ScriptableObject
{
    [SerializeField] PurchasedItemLevel _purchasedItemLevelPrefab;

    public PurchasedItemLevel GetPurchasedItemModel()
    {
        return _purchasedItemLevelPrefab;
    }
}

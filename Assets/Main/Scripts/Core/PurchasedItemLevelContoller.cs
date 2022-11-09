using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasedItemLevelContoller : MonoBehaviour
{
    [SerializeField] List<PurchasedLevelItemCollection> levelCollection = new List<PurchasedLevelItemCollection>();
    [SerializeField] Transform _levelModelParent;
    List<PurchasedItemLevel> _levels = new List<PurchasedItemLevel>();

    public void Initialize()
    {
        int length = DataHandler.PurchasedItemLevel;
        for (int i = 0; i < length; i++)
        {
            LoadLevel(i);
        }
    }
    public void LoadLevel(int levelIndex)
    {
        PurchasedItemLevel level = Instantiate(levelCollection[levelIndex].GetPurchasedItemModel(),_levelModelParent);
        level.Initialize();
        _levels.Add(level);
       
    }
    
}

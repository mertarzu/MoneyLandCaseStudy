using UnityEngine;
using System;
using System.Collections.Generic;

public static class PlayerHelper
{ 
    const int playerMoneyCapacity = 100;
    const int MoneyAmount = 10;
    static int moneyAmount; 

    public static int GetPlayerMoneyCapacity()
    {
        return playerMoneyCapacity;
    }

    public static bool CanPickMoney()
    {
        if (moneyAmount >= playerMoneyCapacity) return false;
        else return true;
    }

    public static void UpdateMoneyAmount(int amount)
    {
        moneyAmount += amount;
        DataHandler.Money += amount * MoneyAmount;       
    }

    public static void ResetMoneyAmount() 
    {
        moneyAmount = 0;
    }

    public static int GetMoneyAmount()
    {
        return moneyAmount;
    }

}
   


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : PooledObject
{
    public Action<bool> OnPurchase;

    bool _isLastOne;
    public bool IsLastOne { get => _isLastOne; set => _isLastOne = value; }

    bool _isTaken;
    public override bool IsPooledObjectTaken => _isTaken;

    [SerializeField] MoneyMover _moneyMover;
 
    public override void Dismiss()
    {
        gameObject.SetActive(false);
        _isTaken = false;
    }

    public override void SetActive()
    {
        gameObject.SetActive(true);
        _isTaken = true;
    }

    public override void SetPosition(Vector3 pos)
    {       
        transform.position = pos;      
    }

    public void Move(Transform moneyTransform,Transform middleTransform,float index)
    {
        _moneyMover.Move(moneyTransform, middleTransform, index);
    }
 
    public void Move(Transform moneyTransform)
    {
        _moneyMover.Move(moneyTransform);
    }

    public void Move(Transform moneyTransform, Vector3 index)
    {      
        _moneyMover.Move(moneyTransform, index);
    }

    public void Purchase()
    {    
        Dismiss();
        if (OnPurchase != null)
            OnPurchase(_isLastOne);
    }
}

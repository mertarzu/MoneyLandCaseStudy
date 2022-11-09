using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    [SerializeField] MaxText _maxText;
    bool _isActive;

    public void Initialize()
    {
        _isActive = false;    
    }

    public void StartGame()
    {
        _isActive = true;
    }
    public void GameOver()
    {
        _isActive = false;
    }

    private void Update()
    {
        if (!_isActive) return;
        if (!PlayerHelper.CanPickMoney())
        {
            _maxText.gameObject.SetActive(true);
        }
        else _maxText.gameObject.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] PlayerFX _playerFX;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] PlayerMoneyHandler _playerMoneyHandler;
    [SerializeField] InputJoyStickController _inputController;
    public Vector3 Output => _inputController.Output;

    bool _isActive;
    
    public void Initialize()
    {      
        _playerFX.Initialize();
        _playerMoneyHandler.Initialize();
        _inputController.enabled = false;    
    }

    public void StartGame()
    {       
        _playerFX.StartGame();
        _playerMoneyHandler.StartGame();
        _inputController.enabled = true;     
        _isActive = true;
    }

    public void GameOver()
    {
        _isActive = false;
        _playerFX.GameOver();
        _playerMoneyHandler.GameOver();
        _inputController.enabled = false;
    }

  
    void Update()
    {
        if (_isActive)
        {
            _inputController.InputUpdate();
            if (Vector3.Magnitude(Output) > 0) MovementUpdate();
                    
        }    
    }
  
    void MovementUpdate()
    {   
        _playerMovement.MovementUpdate(Output);
    }
   
}

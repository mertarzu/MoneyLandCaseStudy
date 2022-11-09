using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] PurchasedItemLevelContoller _purchasedItemLevelController;
    [SerializeField] ScreenManager _screenManager;
    [SerializeField] MoneyContainer _moneyContainer;
    
    private GameState _gameState;
    enum GameState
    {
        Gameplay
    }

    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {
        _playerController.Initialize();    
        _screenManager.Initialize();
        _purchasedItemLevelController.Initialize();
        StartGame();
    }

    public void StartGame()
    {
        _playerController.StartGame();
        _moneyContainer.StartGame();
        SetGamePlayState();
    }

    void SetGamePlayState()
    {
        _screenManager.Hide((int)_gameState);
        _gameState = GameState.Gameplay;    
        _screenManager.Show((int)_gameState);
    }
  
}

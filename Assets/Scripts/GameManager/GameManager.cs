using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class GameManager : StateMachine
  {
    [SerializeField] private int totalCoins = 0;
    public int TotalCoins
    {
      get { return totalCoins; }
      set { totalCoins = value; }
    }
    [SerializeField] private int currentCoins = 0;
    public int CurrentCoins
    {
      get { return currentCoins; }
      set { currentCoins = value; }
    }
    public int FinishStackCount
    {
      get;
      private set;
    }

    public delegate void OnTotalCoinValueChange(int newValue);

    public event OnTotalCoinValueChange OnTotalCoinValueChangeEvent;

    public delegate void OnCurrentCoinValueChange(int newValue);

    public event OnCurrentCoinValueChange OnCurrentCoinValueChangeEvent;

    public delegate void OnGameOver(bool isWin, int coinsCollected);

    public event OnGameOver OnGameOverEvent;

    private AudioManager audioManager;

    private void Awake()
    {
      SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
      audioManager = DIContainer.GetService<AudioManager>();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      FinishStackCount = 0;
      ChangeState(new GameStateWaitingInput());
    }

    private void OnDestroy()
    {
      SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Called when player reaches finish line
    public void OnFinish(int stackCount)
    {
      FinishStackCount = stackCount;
    }

    // Called when player dies or reaches final Lifebuoy after finish
    public void GameOver(bool isWin)
    {
      if (isWin)
      {
        TotalCoins += CurrentCoins;
      }
      ChangeState(new GameStateEnd(isWin));
      OnGameOverEvent?.Invoke(isWin, CurrentCoins);
    }

    public void AddTotalCoins(int amount)
    {
      if (amount > 0)
      {
        audioManager.Play("OnCoin");
      }

      TotalCoins += amount;
      OnTotalCoinValueChangeEvent?.Invoke(TotalCoins);
    }

    public void AddCurrentCoins(int amount)
    {
      if (amount > 0)
      {
        audioManager.Play("OnCoin");
      }

      CurrentCoins += amount;
      OnCurrentCoinValueChangeEvent?.Invoke(CurrentCoins);
    }

  }
}
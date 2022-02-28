using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class GameManager : StateMachine
  {
    [SerializeField] private int coins;
    public int Coins
    {
      get { return coins; }
      set { coins = value; }
    }

    public delegate void OnCoinValueChange(int newValue);

    public event OnCoinValueChange OnCoinValueChangeEvent;

    public delegate void OnGameOver();

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
      ChangeState(new GameStateWaitingInput());
    }

    private void OnDestroy()
    {
      SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void GameOver(bool isWin)
    {
      ChangeState(new GameStateEnd(isWin));
      OnGameOverEvent?.Invoke();
    }

    public void AddCoins(int amount)
    {
      if (amount > 0)
      {
        audioManager.Play("OnCoin");
      }

      Coins += amount;
      OnCoinValueChangeEvent?.Invoke(Coins);
    }

  }
}
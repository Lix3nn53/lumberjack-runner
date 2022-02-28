using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class GameManager : StateMachineDontDestroy
  {
    [SerializeField] private int coins;
    public int Coins
    {
      get { return coins; }
      set { coins = value; }
    }

    public delegate void OnCoinValueChange(int newValue);

    public event OnCoinValueChange OnCoinValueChangeEvent;

    private AudioManager audioManager;

    private void Start()
    {
      ChangeState(new GameStateWaitingInput());

      audioManager = DIContainer.GetService<AudioManager>();
    }


    public void OnGameOver(bool isWin)
    {
      ChangeState(new GameStateEnd(isWin));
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
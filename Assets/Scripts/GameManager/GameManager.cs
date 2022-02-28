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

    private void Start()
    {
      ChangeState(new GameStateWaitingInput());
    }


    public void OnGameOver(bool isWin)
    {
      ChangeState(new GameStateEnd(isWin));
    }

    public void AddCoins(int amount)
    {
      Coins += amount;
      OnCoinValueChangeEvent?.Invoke(Coins);
    }
  }
}
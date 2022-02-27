using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class GameStateEnd : IState
  {
    private bool IsWin { get; set; }

    private PlayerAnimationController playerAnimationController;
    public GameStateEnd(bool isWin)
    {
      IsWin = isWin;

      playerAnimationController = DIContainer.GetService<PlayerAnimationController>();
    }

    public void Enter()
    {
      if (IsWin)
      {
        Debug.Log("You win!");
      }
      else
      {
        Debug.Log("You lose!");
      }

      playerAnimationController.OnGameOver(IsWin);
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
  }
}
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
    private CameraRotator cameraRotator;
    public GameStateEnd(bool isWin)
    {
      IsWin = isWin;

      playerAnimationController = DIContainer.GetService<PlayerAnimationController>();
      cameraRotator = DIContainer.GetService<CameraRotator>();
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
      cameraRotator.enabled = true;
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
  }
}
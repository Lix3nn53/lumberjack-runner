using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class GameManager : StateMachine
  {
    private void Start()
    {
      ChangeState(new GameStateWaitingInput());
    }


    public void OnGameOver(bool isWin)
    {
      ChangeState(new GameStateEnd(isWin));
    }
  }
}
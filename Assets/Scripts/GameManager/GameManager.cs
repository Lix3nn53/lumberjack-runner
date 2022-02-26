using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;

namespace Lix.CubeRunner
{
  public class GameManager : StateMachine
  {
    private void Start()
    {
      ChangeState(new GameStatePlay());

      IInputListener inputListener = DIContainer.GetService<IInputListener>();

      inputListener.GetAction(InputActionType.Pause).performed += OnPauseInputPerformed;
    }

    private void OnPauseInputPerformed(InputAction.CallbackContext context)
    {

      if (CurrentState is GameStatePause)
      {
        ChangeState(new GameStatePlay());
      }
      else
      {
        ChangeState(new GameStatePause());
      }
    }

  }
}
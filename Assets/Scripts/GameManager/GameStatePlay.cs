using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class GameStatePlay : IState
  {
    private GameManager gameManager;
    private IInputListener inputListener;
    private InGameMenu inGameMenu;
    public void Enter()
    {
      inputListener = DIContainer.GetService<IInputListener>();

      inputListener.GetAction(InputActionType.Pause).performed += OnPauseInputPerformed;

      gameManager = DIContainer.GetService<GameManager>();

      inGameMenu = DIContainer.GetService<InGameMenu>();

      inGameMenu.Panel.SetActive(true);
    }

    private void OnPauseInputPerformed(InputAction.CallbackContext context)
    {
      gameManager.ChangeState(new GameStatePause());
    }

    public void Execute()
    {

    }

    public void Exit()
    {
      inputListener.GetAction(InputActionType.Pause).performed -= OnPauseInputPerformed;

      if (inGameMenu != null)
      {
        inGameMenu.Panel.SetActive(false);
      }
    }
  }
}
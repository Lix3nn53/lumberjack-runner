using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class GameStatePause : IState
  {
    private PauseMenu pauseMenu;

    private GameManager gameManager;
    private IInputListener inputListener;
    public void Enter()
    {
      pauseMenu = DIContainer.GetService<PauseMenu>();

      inputListener = DIContainer.GetService<IInputListener>();

      inputListener.GetAction(InputActionType.Pause).performed += OnPauseInputPerformed;

      gameManager = DIContainer.GetService<GameManager>();

      Pause();
    }

    private void OnPauseInputPerformed(InputAction.CallbackContext context)
    {
      gameManager.ChangeState(new GameStatePlay());
    }

    public void Execute()
    {

    }

    public void Exit()
    {
      inputListener.GetAction(InputActionType.Pause).performed -= OnPauseInputPerformed;
      Resume();
    }

    private void Pause()
    {
      Time.timeScale = 0f;
      pauseMenu.Panel.SetActive(true);
    }

    private void Resume()
    {
      Time.timeScale = 1f;
      pauseMenu.Panel.SetActive(false);
    }
  }
}
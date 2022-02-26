using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class GameStatePause : IState
  {
    private PauseMenu pauseMenu;

    public GameStatePause()
    {
      pauseMenu = DIContainer.GetService<PauseMenu>();
    }

    public void Enter()
    {
      Pause();
    }

    public void Execute()
    {

    }

    public void Exit()
    {
      Resume();
    }

    private void Pause()
    {
      Time.timeScale = 0f;
      pauseMenu.PauseMenuPanel.SetActive(true);
    }

    private void Resume()
    {
      Time.timeScale = 1f;
      pauseMenu.PauseMenuPanel.SetActive(false);
    }
  }
}
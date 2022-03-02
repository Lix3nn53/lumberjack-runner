using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;


namespace Lix.LumberjackRunner
{

  public class PauseButton : MonoBehaviour
  {
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = DIContainer.GetService<GameManager>();
    }

    public void OnPauseButtonClicked()
    {
      if (gameManager.CurrentState.GetType() == typeof(GameStatePlay))
      {
        gameManager.ChangeState(new GameStatePause());
      }
      else if (gameManager.CurrentState.GetType() == typeof(GameStatePause))
      {
        gameManager.ChangeState(new GameStatePlay());
      }
    }
  }
}
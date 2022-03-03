using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class GameStateWaitingInput : IState
  {
    private WaitingInputMenu waitingInputMenu;
    private GameManager gameManager;
    private IInputListener inputListener;
    private PlayerMovement playerMovement;
    public void Enter()
    {
      waitingInputMenu = DIContainer.GetService<WaitingInputMenu>();

      inputListener = DIContainer.GetService<IInputListener>();

      gameManager = DIContainer.GetService<GameManager>();

      playerMovement = DIContainer.GetService<PlayerMovement>();

      DIContainer.GetService<CurvedWorldManager>().SetEnable(true);
      Pause();

      delayedInputRegister();
    }

    private async Task delayedInputRegister()
    {
      await Task.Delay(1000);

      inputListener.GetAction(InputActionType.Move).performed += OnMoveInputPerformed;
    }

    private void OnMoveInputPerformed(InputAction.CallbackContext context)
    {
      gameManager.ChangeState(new GameStatePlay());
    }

    public void Execute()
    {

    }

    public void Exit()
    {
      inputListener.GetAction(InputActionType.Move).performed -= OnMoveInputPerformed;
      Resume();
    }

    private void Pause()
    {
      playerMovement.StopRunning();
      waitingInputMenu.Panel.SetActive(true);
    }

    private void Resume()
    {
      playerMovement.StartRunning();
      waitingInputMenu.Panel.SetActive(false);
    }
  }
}
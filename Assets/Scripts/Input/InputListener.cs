using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  [RequireComponent(typeof(PlayerInput))]
  public class InputListener : MonoBehaviour, IInputListener
  {

    private PlayerInput playerInput;
    private InputAction ActionMove;
    private InputAction ActionPause;

    protected void Awake()
    {
      if (playerInput != null) return;

      playerInput = GetComponent<PlayerInput>();

      if (playerInput == null) return;
      if (playerInput.currentActionMap == null) return;

      ActionMove = playerInput.currentActionMap.FindAction("Move");

      ActionPause = playerInput.currentActionMap.FindAction("Pause");
    }

    public InputAction GetAction(InputActionType type)
    {
      switch (type)
      {
        case InputActionType.Move:
          return ActionMove;
        case InputActionType.Pause:
          return ActionPause;
        default:
          return null;
      }
    }
  }
}
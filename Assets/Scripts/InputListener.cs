using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;

namespace Lix.CubeRunner
{
  [RequireComponent(typeof(PlayerInput))]
  public class InputListener : DontDestroy, IInputListener
  {

    private PlayerInput playerInput;
    private InputAction ActionMove;
    private InputAction ActionPause;

    protected override void Awake()
    {
      base.Awake();

      playerInput = GetComponent<PlayerInput>();

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
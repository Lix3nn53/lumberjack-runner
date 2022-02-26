using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lix.CubeRunner
{
  public enum InputActionType { Move, Pause }
  public interface IInputListener
  {
    InputAction GetAction(InputActionType type);
  }
}
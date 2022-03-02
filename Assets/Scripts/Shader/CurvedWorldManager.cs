using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CurvedWorldManager : MonoBehaviour
{
  private const string ENABLED = "_ENABLE";
  [SerializeField] private bool enable = true;

  private void Update()
  {

    if (enable)
    {
      if (!Shader.IsKeywordEnabled(ENABLED))
      {
        Shader.EnableKeyword(ENABLED);
      }
    }
    else
    {
      Shader.DisableKeyword(ENABLED);
    }

    this.enabled = false;
  }

  public void SetEnable(bool enable)
  {
    this.enabled = true;
    this.enable = enable;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CurvedWorldManager : MonoBehaviour
{
  private const string ENABLED = "_ENABLE";
  [SerializeField] private bool alwaysEnable = false;

  private void Update()
  {

    if (alwaysEnable)
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
  }
}

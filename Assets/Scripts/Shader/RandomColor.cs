using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lix.CubeRunner
{
  public class RandomColor : MonoBehaviour
  {
    private void Awake()
    {
      MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
      Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
      materialPropertyBlock.SetColor("_BaseColor", randomColor);

      Renderer[] renderers = GetComponentsInChildren<Renderer>();

      foreach (Renderer renderer in renderers)
      {
        materialPropertyBlock.SetColor("_BaseColor", randomColor);
        renderer.SetPropertyBlock(materialPropertyBlock);
      }
    }
  }
}
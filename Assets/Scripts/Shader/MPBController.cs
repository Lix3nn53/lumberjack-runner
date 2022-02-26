using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lix.CubeRunner
{
  public class MPBController : MonoBehaviour
  {
    [SerializeField] private Color mainColor = Color.black;

    private Renderer _renderer = null;
    private MaterialPropertyBlock materialPropertyBlock = null;

    private void Awake()
    {
      _renderer = GetComponent<Renderer>();
      materialPropertyBlock = new MaterialPropertyBlock();

      materialPropertyBlock.SetColor("_BaseColor", mainColor);
      _renderer.SetPropertyBlock(materialPropertyBlock);
    }
  }
}
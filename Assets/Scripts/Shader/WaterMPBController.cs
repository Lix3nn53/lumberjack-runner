using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMPBController : MonoBehaviour
{
  [SerializeField] private float rippleSpeed = 1f;
  [SerializeField] private float rippleDensity = 5f;
  [SerializeField] private float rippleSlimness = 3f;

  private Renderer _renderer = null;
  private MaterialPropertyBlock materialPropertyBlock = null;

  private void Awake()
  {
    _renderer = GetComponent<Renderer>();
    materialPropertyBlock = new MaterialPropertyBlock();

    materialPropertyBlock.SetFloat("_RippleSpeed", rippleSpeed);

    materialPropertyBlock.SetFloat("_RippleDensity", rippleDensity);

    materialPropertyBlock.SetFloat("_RippleSlimness", rippleSlimness);

    _renderer.SetPropertyBlock(materialPropertyBlock);
  }
}

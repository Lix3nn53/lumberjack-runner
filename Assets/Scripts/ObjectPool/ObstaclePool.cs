using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Lix.Core;

namespace Lix.CubeRunner
{
  public class ObstaclePool : GameObjectPool
  {
    protected override void Awake()
    {
      PoolManager.Add(this.GetType().Name, this);
    }
  }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class Obstacle : Triggerable
  {
    // Dependencies
    private PlayerCollider playerCollider;
    private PlayerMovement playerMovement;

    private void Start()
    {
      playerCollider = DIContainer.GetService<PlayerCollider>();
      playerMovement = DIContainer.GetService<PlayerMovement>();
    }

    public override void OnTrigger(Collider other)
    {
      Debug.Log(other.gameObject.name);
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      playerCollider.OnObstacle();
    }
  }
}
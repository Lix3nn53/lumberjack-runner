using System;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class WaterObstacleDrown : Triggerable
  {
    private PlayerMovement playerMovement;
    private GameManager gameManager;

    private void Start()
    {
      playerMovement = DIContainer.GetService<PlayerMovement>();
      gameManager = DIContainer.GetService<GameManager>();
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      playerMovement.StopRunning();
      gameManager.OnGameOver(false);
    }
  }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class WaterObstacleDrown : Triggerable
  {
    private PlayerMovement playerMovement;
    private PlayerCollider playerCollider;
    private GameManager gameManager;
    private PlayerAnimationController playerAnimationController;

    private void Start()
    {
      playerMovement = DIContainer.GetService<PlayerMovement>();
      playerCollider = DIContainer.GetService<PlayerCollider>();
      gameManager = DIContainer.GetService<GameManager>();
      playerAnimationController = DIContainer.GetService<PlayerAnimationController>();
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      Debug.Log("Drown");

      playerMovement.StopRunning();
      gameManager.GameOver(false);
      playerCollider.OnDrown();
      playerAnimationController.OnGameOverDrown();
    }
  }
}
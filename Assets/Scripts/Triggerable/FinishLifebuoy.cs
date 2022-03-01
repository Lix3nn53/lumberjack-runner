using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class FinishLifebuoy : Triggerable
  {
    [SerializeField] private int requiredStack = 2;
    private GameManager gameManager;
    private PlayerMovement playerMovement;

    private void Start()
    {
      gameManager = DIContainer.GetService<GameManager>();
      playerMovement = DIContainer.GetService<PlayerMovement>();
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      if (gameManager.FinishStackCount < requiredStack)
      {
        playerMovement.StopRunning();
        gameManager.GameOver(true);
      }

      Destroy(this);
    }
  }
}
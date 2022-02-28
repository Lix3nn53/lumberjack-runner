using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class Coin : Triggerable
  {
    private GameManager gameManager;

    private void Start()
    {
      gameManager = DIContainer.GetService<GameManager>();
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      gameManager.AddCoins(1);

      Destroy(this.gameObject);
    }
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class Finish : Triggerable
  {
    private PlayerMovement playerMovement;

    private void Start()
    {
      playerMovement = DIContainer.GetService<PlayerMovement>();
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      playerMovement.StopRunning();

      Destroy(this);
    }
  }
}
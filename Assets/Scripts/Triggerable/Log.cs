using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class Log : Triggerable
  {
    private PlayerCollider playerCollider;

    private void Start()
    {
      playerCollider = DIContainer.GetService<PlayerCollider>();
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      playerCollider.OnStack(this.gameObject);

      // The logs player is carrying affacted by gravity
      this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
      this.gameObject.GetComponent<Rigidbody>().isKinematic = false;

      Destroy(this); // Removes this script instance from the game object
    }
  }
}
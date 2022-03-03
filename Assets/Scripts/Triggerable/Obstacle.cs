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

    private GameObject graphics;

    private void Start()
    {
      playerCollider = DIContainer.GetService<PlayerCollider>();
      playerMovement = DIContainer.GetService<PlayerMovement>();

      graphics = transform.GetChild(0).gameObject;
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      playerCollider.OnObstacle();
    }

    protected virtual void Update()
    {
      graphics.transform.Rotate(Vector3.forward, Time.deltaTime * 100);
    }
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
using Lix.LumberjackRunner;

public class ContainerGame : DIContainerRegisterMono
{
  [SerializeField] private PlayerCollider playerCollider;
  [SerializeField] private PlayerMovement playerMovement;
  [SerializeField] private TrackManager trackManager;

  public override void RegisterDependencies()
  {
    DIContainer.Register(new ServiceDescriptor(playerCollider, ServiceLifetime.Singleton));

    DIContainer.Register(new ServiceDescriptor(playerMovement, ServiceLifetime.Singleton));

    // DIContainer.Register(new ServiceDescriptor(trackManager, ServiceLifetime.Singleton));
  }
}

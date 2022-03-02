using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
using Lix.LumberjackRunner;

public class ContainerGameFinish : DIContainerRegisterMono
{
  [SerializeField] private CurvedWorldManager curvedWorldManager;

  [SerializeField] private CameraRotator cameraRotator;

  public override void RegisterDependencies()
  {
    DIContainer.Register(new ServiceDescriptor(curvedWorldManager, ServiceLifetime.Singleton));

    DIContainer.Register(new ServiceDescriptor(cameraRotator, ServiceLifetime.Transient));

    // DIContainer.Register(new ServiceDescriptor(trackManager, ServiceLifetime.Singleton));
  }
}

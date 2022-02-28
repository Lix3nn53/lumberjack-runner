using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
using Lix.LumberjackRunner;

public class ContainerUI : DIContainerRegisterMono
{
  [SerializeField] private WaitingInputMenu waitingInputMenu;
  [SerializeField] private PauseMenu pauseMenu;
  [SerializeField] private CoinMenu coinMenu;

  public override void RegisterDependencies()
  {
    DIContainer.Register(new ServiceDescriptor(waitingInputMenu, ServiceLifetime.Transient));

    DIContainer.Register(new ServiceDescriptor(pauseMenu, ServiceLifetime.Transient));

    DIContainer.Register(new ServiceDescriptor(coinMenu, ServiceLifetime.Transient));
  }
}

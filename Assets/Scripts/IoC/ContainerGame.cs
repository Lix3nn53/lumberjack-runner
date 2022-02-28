using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
using Lix.LumberjackRunner;

public class ContainerGame : DIContainerRegisterMono
{
  [SerializeField] private PlayerCollider playerCollider;
  [SerializeField] private PlayerMovement playerMovement;
  [SerializeField] private GameManager gameManager;
  [SerializeField] private AudioManager audioManager;
  [SerializeField] private PlayerAnimationController playerAnimationController;

  public override void RegisterDependencies()
  {
    DIContainer.Register(new ServiceDescriptor(playerCollider, ServiceLifetime.Transient));

    DIContainer.Register(new ServiceDescriptor(playerMovement, ServiceLifetime.Transient));

    DIContainer.Register(new ServiceDescriptor(gameManager, ServiceLifetime.Singleton));

    DIContainer.Register(new ServiceDescriptor(audioManager, ServiceLifetime.Singleton));

    DIContainer.Register(new ServiceDescriptor(playerAnimationController, ServiceLifetime.Transient));

    // DIContainer.Register(new ServiceDescriptor(trackManager, ServiceLifetime.Singleton));
  }
}

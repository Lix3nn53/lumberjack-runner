using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class Coin : Triggerable
  {
    [SerializeField] private int coin = 1;
    [SerializeField] private float rotationSpeed = 1;
    private GameManager gameManager;

    private void Start()
    {
      gameManager = DIContainer.GetService<GameManager>();
    }

    private void Update()
    {
           transform.Rotate ( Vector3.up * ( rotationSpeed * Time.deltaTime ) );
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      gameManager.AddCurrentCoins(coin);

      Destroy(this.gameObject);
    }
  }
}
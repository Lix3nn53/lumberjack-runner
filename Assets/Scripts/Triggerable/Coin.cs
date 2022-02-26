using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class Coin : Triggerable
  {
    private CoinMenu coinMenu;

    private void Start()
    {
      coinMenu = DIContainer.GetService<CoinMenu>();
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      coinMenu.OnCoinCollect(1);

      Destroy(this.gameObject);
    }
  }
}
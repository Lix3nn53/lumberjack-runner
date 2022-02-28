using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
using TMPro;

namespace Lix.LumberjackRunner
{

  public class StackShop : MonoBehaviour
  {
    [SerializeField] private GameObject stackPrefab;
    [SerializeField] private TMP_Text stackCountText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private int maxStackCount = 5;
    [SerializeField] private GameObject[] disableOnMax;
    private PlayerCollider playerCollider;

    private GameManager gameManager;

    private int price = 10;
    private void Start()
    {
      playerCollider = DIContainer.GetService<PlayerCollider>();
      gameManager = DIContainer.GetService<GameManager>();

      priceText.text = price.ToString();
    }

    public void BuyStack()
    {
      if (gameManager.Coins < price)
      {
        return;
      }

      int stackCount = playerCollider.GetStackCount();

      if (stackCount < maxStackCount)
      {
        GameObject stack = Instantiate(stackPrefab);
        playerCollider.OnStack(stack);
        stackCountText.text = "x" + (stackCount + 1);

        gameManager.AddCoins(-price);
        this.price += 5;

        if (stackCount == maxStackCount - 1)
        {
          priceText.text = "Max";

          foreach (var item in disableOnMax)
          {
            item.SetActive(false);
          }
        }
        else
        {
          priceText.text = price.ToString();
        }
      }
    }
  }
}
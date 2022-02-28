using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class CoinMenu : MonoBehaviour
  {
    [SerializeField] private TMP_Text text;

    private GameManager gameManager;

    private void Start()
    {
      gameManager = DIContainer.GetService<GameManager>();

      gameManager.OnCoinValueChangeEvent += OnCoinValueChange;

      text.text = gameManager.Coins.ToString();
    }

    public void OnCoinValueChange(int amount)
    {
      text.text = gameManager.Coins.ToString();
    }
  }
}